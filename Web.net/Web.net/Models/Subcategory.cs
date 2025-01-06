using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Subcategory
{
    public string SubcategoryId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
