
namespace API.Net.ViewModel
{
  
        public class OrderModel
        {

            public int OrderID { get; set; } // Lấy từ người dùng, không cần nhập từ phía client.

            public int UserId { get; set; } // Lấy từ người dùng, không cần nhập từ phía client.
            public string Fullname { get; set; }
            public string Email { get; set; }
            public int PhoneNumber { get; set; }
            public string Address { get; set; }
            public int PaymentId { get; set; }
            public decimal TotalPrice { get; set; }
            public int OrderStatusId { get; set; } = 1; // Giả sử 1 là trạng thái mặc định là "Chờ xác nhận"
            public string Note { get; set; }

            public int fee { get; set; } = 0;

             public int discount { get; set; } = 0; // Giả sử 1 là trạng thái mặc định là "Chờ xác nhận"

        // Giả sử 1 là trạng thái mặc định là "Chờ xác nhận"

        public List<OrderDetailModel> Items { get; set; } = new List<OrderDetailModel>();


        }
    
}
