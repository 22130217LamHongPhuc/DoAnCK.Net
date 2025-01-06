using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Web.net.Models;
using Web.net.Service;

namespace Web.net.Controllers
{
    public class VoucherController : Controller
    {

        private readonly VoucherService voucherService;


        public VoucherController(VoucherService orderService)
        {

            voucherService = orderService;

        }



        [HttpGet]
        public async Task<IActionResult> CheckVoucher(string code)
        {

            Cart cart = HttpContext.Session.GetObject<Cart>("cart");

            if (cart == null)
            {
                cart = new Cart();
            }
            var voucher = await voucherService.GetVoucherByCondition(code, cart.TotalPriceCart());

            if (voucher != null)
            {
                cart.SetDiscount(voucher);

                HttpContext.Session.SetObject("cart", cart);

                return Json(new { success = true, discount =cart.discount , size = cart.CartSize(), status = "Áp mã giảm giá " +code +" thành công" , totalPrice = cart.totalPriceUseVoucher()});
            }
            else
            {
                cart.discount = 0;
            }


            HttpContext.Session.SetObject("cart", cart);








            return Json(new { success = false, message = "Su dung ma that bai", size = cart.CartSize(), status ="Ma giảm giá không tồn tại hoặc chưa hợp lệ" , discount = 0, totalPrice = cart.totalPriceUseVoucher() });
        }
    }
}
