using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Vouchertype
{
    public int TypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
