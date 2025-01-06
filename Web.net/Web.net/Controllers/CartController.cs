using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Web.net.Models;
using Web.net.Service;

namespace Web.net.Controllers
{

  
    public class CartController : Controller
    {



        public IActionResult getCart()

        {
            Cart cart = HttpContext.Session.GetObject<Cart>("cart");

            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.SetObject("cart", cart);
            }

            ViewBag.Cart = cart;

            return View("Cart");
        }


        [HttpPost]
        public ActionResult AddToCart(string productId, string name, int price,int discount, string thumbnail,int quantity)  {
            Cart cart = HttpContext.Session.GetObject<Cart>("cart");

            if (cart == null)
            {
                cart = new Cart();
               

            }


            cart.AddCartItem(new Product(productId, name, price,discount, thumbnail), quantity);


            HttpContext.Session.SetObject("cart", cart);

            // Trả về phản hồi JSON cho Aja
            return Json(new { success = true,message="Thêm vào giỏ hàng thành công",size=cart.CartSize() });
        }



        [HttpPost]
        public IActionResult UpdateQuantity(string productId, int quatity)
        {
            var cart = (Cart) HttpContext.Session.GetObject<Cart>("cart");

            var cartItem = cart.carts.Values.FirstOrDefault(i => i.ProductID == productId);

            if (cartItem != null)
            {
                cartItem.Quatity = quatity;
               
                HttpContext.Session.SetObject("cart", cart);

                return Json(new
                {
                    success = true,
                    totalpriceitem = cartItem.TotalPriceCartItem(),
                    totalpricecart = cart.TotalPriceCart()
                });
            }

            return Json(new { success = false });
        }


        [HttpDelete]
        public IActionResult RemoveCartItem(string productId)
        {

            var cart = (Cart)HttpContext.Session.GetObject<Cart>("cart");

            var cartItem = cart.carts.Values.FirstOrDefault(i => i.ProductID == productId);


            if (cartItem != null)
            {
                cart.RemoveCartItem(productId);

                HttpContext.Session.SetObject("cart", cart);

                return Json(new
                {
                    success = true,
                    size = cart.CartSize(),
                    totalpricecart = cart.TotalPriceCart()


                });
            }

            return Json(new { success = false });


        }


    }
}
