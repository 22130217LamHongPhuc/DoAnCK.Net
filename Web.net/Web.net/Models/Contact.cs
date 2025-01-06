using System;
using System.Collections.Generic;

namespace API.Net.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string Fullname { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;
}
