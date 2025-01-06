using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
}
