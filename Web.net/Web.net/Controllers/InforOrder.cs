using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.net.Service;

namespace Web.net.Controllers
{
    public class InforOrder : Controller
    {
        public IActionResult Index(string userEmail)
        {

            Order order = HttpContext.Session.GetObject<Order>("order");

            if (order != null)
            {
                ViewBag.Order = order;

            }

            return View();
        }

        public IActionResult BackToHome()
        {
           
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
