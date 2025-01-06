using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class OrderDetail
{
    public OrderDetail( string productId, int quantity, decimal totalPrice)
    {
        
        ProductId = productId;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }

    public int OrderId { get; set; }

    public string ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }


}
