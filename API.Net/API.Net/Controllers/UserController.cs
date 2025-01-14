using API.Net.Models;
using API.Net.ViewModel;
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

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { message = "Email và mật khẩu không được để trống." });
            }

            try
            {
                
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password==password);

              if(user == null)
                {
                    return StatusCode(404, new { message = "Khong tim thay user." });

                }

                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình xử lý.", error = ex.Message });
            }
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel usermodel)
        {


            User user = new User
            {
                FullName = usermodel.FullName,
                Email = usermodel.Email,
                PhoneNumber = usermodel.PhoneNumber,
                Password = usermodel.Password
            };
            try
            {
                

                user.CreateAt = DateTime.UtcNow;          
                user.RoleId = 1;                         
                user.PhoneNumber = user.PhoneNumber ?? 0; 

                // Lưu vào cơ sở dữ liệu
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Đăng ký thành công.",
                    user = new
                    {
                        user.UserId,

                        user.FullName,
                        user.Email,
                        user.PhoneNumber,
            
                        user.CreateAt
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình xử lý.", error = ex.Message });
            }
        }







    }

}
