using System;
using System.Collections.Generic;
using Dal.Models;
using Dto.Classes;

namespace Dto.Classes;

public partial class Trip
{
    public int Id { get; set; }

    public string? Destination { get; set; }

    public int? Type { get; set; }

    public string? TypeName { get; set; }

    public bool? needMedic { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Departure { get; set; }

    public double? Hours { get; set; }

    public int? Vacancys { get; set; }

    public double? Price { get; set; }

    public string? Img { get; set; }


} 