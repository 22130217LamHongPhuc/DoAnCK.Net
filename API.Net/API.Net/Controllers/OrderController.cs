using API.Net.Models;
using API.Net.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Net.Controllers
{

    [Route("order")]
    public class OrderController : Controller
    {

        private readonly DbtestContext _context;

        public OrderController(DbtestContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderModel orderModel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        UserId = orderModel.UserId,
                        Fullname = orderModel.Fullname,
                        Email = orderModel.Email,
                        PhoneNumber = orderModel.PhoneNumber,
                        Address = orderModel.Address,
                        PaymentId = orderModel.PaymentId,
                        TotalPrice = orderModel.TotalPrice,
                        OrderStatusId = orderModel.OrderStatusId,
                        Note = orderModel.Note,
                        fee = orderModel.fee,
                        discount = orderModel.discount
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    foreach (var item in orderModel.Items)
                    {
                        _context.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = order.OrderId, // Đã có OrderId từ database sau khi lưu Order
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            TotalPrice = item.TotalPrice
                        });
                    }

                    _context.SaveChanges(); // Lưu OrderDetails

                    transaction.Commit();

                    return Ok("create success order ");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, "An error : " + ex.Message);
                }
            }
        }

    }
}
