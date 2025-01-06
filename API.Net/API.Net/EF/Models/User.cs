using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public int? PhoneNumber { get; set; }

    public int RoleId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual Role Role { get; set; } = null!;
}
