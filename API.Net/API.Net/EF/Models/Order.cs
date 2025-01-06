using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string Fullname { get; set; } = null!;
    public string Note { get; set; } = null!;
    public int fee { get; set; }
    public int discount { get; set; }





    public string Email { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string Address { get; set; } = null!;

    public int PaymentId { get; set; }

    public int OrderStatusId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateOnly? CreateAt { get; set; }

    public DateOnly? DeliveredDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
