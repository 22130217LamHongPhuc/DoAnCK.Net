using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Subimage
{
    public int SubImagesId { get; set; }

    public string Image { get; set; } = null!;

    public DateOnly? CreateDate { get; set; }

    public string ProductId { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
