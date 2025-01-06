using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class ProductView
{
    public int ProductViewId { get; set; }

    public string ProductId { get; set; } = null!;

    public DateOnly CreateAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
