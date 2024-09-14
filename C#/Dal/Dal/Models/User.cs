using System;
using System.Collections.Generic;

namespace Dal.Models;


public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public bool? FirstAidCertificate { get; set; }

    public virtual ICollection<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();
}
