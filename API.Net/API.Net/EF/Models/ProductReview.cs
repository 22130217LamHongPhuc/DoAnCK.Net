using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class ProductReview
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public string ProductId { get; set; } = null!;

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Fullname { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
