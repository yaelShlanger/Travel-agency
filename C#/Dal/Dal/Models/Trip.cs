using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Trip
{
    public int Id { get; set; }

    public string? Destination { get; set; }

    public int? Type { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Departure { get; set; }

    public double? Hours { get; set; }

    public int? Vacancys { get; set; }

    public double? Price { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();

    public virtual TripType? TypeNavigation { get; set; }


}
