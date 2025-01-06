namespace API.Net.ViewModel
{
    public class OrderDetailModel
    {
        public int OrderId { get; set; }

        public string ProductId { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
