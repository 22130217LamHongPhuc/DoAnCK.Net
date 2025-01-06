using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Newtype
{
    public int NewTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual News? News { get; set; }
}
