using API.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Net.Controllers
{
    [Route("vouchers")]  // Route cơ bản cho controller

    public class VoucherController : Controller
    {

        private readonly DbtestContext _context;

        public VoucherController(DbtestContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetRandomVoucher()
        {
            var vouchers = _context.Vouchers.Take(3).ToList();
            return Ok(vouchers);
        }


        [HttpGet("voucher-condition")]
        public IActionResult SelectByCodeHasCondition(string code, int totalPrice)
        {
            try
            {
                var voucher = _context.Vouchers
                    .FirstOrDefault(v => v.Code == code && v.MinOrderValue <= totalPrice);
                if (voucher == null)
                {
                    return NotFound(new { message = "Voucher not found or does not meet the condition." });
                }

                return Ok(voucher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

    }
}
