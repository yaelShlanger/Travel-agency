using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface Icontext
    {
        public DbSet<OrderTicket> OrderTickets { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<TripType> TripType { get; set; }
        public DbSet<User> User { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken= default(CancellationToken));
    }
}
