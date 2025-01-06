using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string MethodPayment { get; set; } = null!;
}
