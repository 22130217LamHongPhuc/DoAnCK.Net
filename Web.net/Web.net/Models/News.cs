using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class News
{
    public int NewId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreateAt { get; set; }

    public string Thumbnail { get; set; } = null!;

    public int NewTypeId { get; set; }

    public virtual Newtype New { get; set; } = null!;
}
