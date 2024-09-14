using System;
using System.Collections.Generic;
namespace Dal.Models;

public partial class TripType
{
    public int Id { get; set; }

    public string? TripName { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}