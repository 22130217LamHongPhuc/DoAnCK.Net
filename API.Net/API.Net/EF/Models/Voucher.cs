using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? TypeId { get; set; }

    public int? VoucherPercent { get; set; }

    public int? VoucherCash { get; set; }

    public int? MaximumValue { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Vouchertype? Type { get; set; }

    public int? MinOrderValue { get; set; }

}
