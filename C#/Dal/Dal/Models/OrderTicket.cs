using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class OrderTicket
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? OrderTime { get; set; }

    public int? Hours { get; set; }

    public int? TripId { get; set; }

    public int? Tickets { get; set; }

    public virtual Trip? Trip { get; set; }

    public virtual User? User { get; set; }
}
