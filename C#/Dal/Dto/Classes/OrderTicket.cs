using System;
using System.Collections.Generic;
namespace Dto.Classes;

public partial class OrderTicket
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? fullName { get; set; }

    public string? destination {  get; set; }
   /*תאריך הזמנת הטיול*/
    public DateTime? Date { get; set; }
    /*תאריך יציאה לטיול*/
    public DateTime? DateOfTrip { get; set; }
    /*שעת ההזמנה */
    public TimeSpan? OrderTime { get; set; }

    public int? Hours { get; set; }

    public int? TripId { get; set; }

    public int? Tickets { get; set; }

}
