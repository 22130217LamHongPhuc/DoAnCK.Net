using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Net.Controllers
{
    [Route("users")]  // Route cơ bản cho controller
    public class UserController : Controller
    {
        private readonly DbtestContext _context;

        public UserController(DbtestContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sản phẩm



        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            // Lấy toàn bộ sản phẩm
            return Ok(users);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Lấy một sản phẩm theo ID
            var user = _context.Users
                .Include(p => p.Orders)
         .FirstOrDefault(p => p.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }


    }

}
