using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Web.net.Models;
using Web.net.Service;

namespace Web.net.Controllers
{
    public class HomeController : Controller
    {


        private readonly ProductService _productService;


        public HomeController(ProductService productService)
        {

            _productService = productService;

        }


        public async Task<IActionResult> Index()
        {

            ViewBag.ProductsDate = await _productService.GetProductHighestDate();
            ViewBag.ProductsPrice = await _productService.GetProductHighestPrice();
            ViewBag.ProductsBestSeller = await _productService.GetProductBestSeller();

           
            return View();

        }


       
   

}
}
