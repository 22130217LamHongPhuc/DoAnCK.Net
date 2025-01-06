using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Specification
{
    public string SpecificationId { get; set; } = null!;

    public string? Dimensions { get; set; }

    public string? Material { get; set; }

    public string? Original { get; set; }

    public string? Standard { get; set; }

    public string? ProductId { get; set; }

    public virtual Product SpecificationNavigation { get; set; } = null!;
}
