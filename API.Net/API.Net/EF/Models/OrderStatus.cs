using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
