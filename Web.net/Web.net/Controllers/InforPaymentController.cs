using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Web.net.Models;
using Web.net.Service;

namespace Web.net.Controllers
{
    public class InforPaymentController : Controller

      

    {


        private readonly VoucherService voucherService;


        public InforPaymentController(VoucherService orderService)
        {

            voucherService = orderService;

        }

        public async Task<IActionResult> Index()
        {

            Cart cart = HttpContext.Session.GetObject<Cart>("cart");

            var vouchers = await voucherService.GelVoucher();

            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.SetObject("cart", cart);
            }

            ViewBag.Cart = cart;
            ViewBag.Vouchers = vouchers;

            return View("InforPayment");
        }
    }
}
