using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Order
{

    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string Address { get; set; }
    public int PaymentId { get; set; }
    public string PaymentName { get; set; }

    public int OrderStatusId { get; set; }

    public string OrderStatusName { get; set; }

    public decimal TotalPrice { get; set; }
    public DateTime CreateAt { get; set; }
    public string? DeliveredDate { get; set; }
    public List<OrderDetail> Items { get; set; }

    public int? fee { get; set; }
    public int? discount { get; set; } 
    public string? Note { get; set; }


}
