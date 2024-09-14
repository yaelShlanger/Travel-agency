using Dal.Interfaces;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Functions
{
    public class Trip : ITrip
    {
        private TheOrganizedTourContext db;
        public Trip(TheOrganizedTourContext db) { this.db = db; }

        public async Task<int> AddAsync(Models.Trip Trip)
        {
            db.Trips.Add(Trip);
            await db.SaveChangesAsync();    
            return Trip.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await GetByIdAsync(id);
            if (delete != null)
            {
                db.Trips.Remove(delete);
                await db.SaveChangesAsync();
                return true;
            }
            return false; 
        }

        public async Task<List<Models.Trip>> GetAllAsync()
        {
            return await db.Trips.Include(p=>p.OrderTickets).Include(p=>p.TypeNavigation).ToListAsync();    
        }

        public async Task<Models.Trip> GetByIdAsync(int id)
        {
            List<Models.Trip> trip =db.Trips.Include(p => p.OrderTickets).Include(p => p.TypeNavigation).ToList();
            Models.Trip x =trip.FirstOrDefault(p => p.Id == id);
            return x;
        }

        public async Task<bool> UpdateAsync(Models.Trip Trip)
        {
            var current =this.db.Trips.SingleOrDefault(p => p.Id == Trip.Id);
            if (current != null)
            {
                db.Entry(current).CurrentValues.SetValues(Trip);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> checkMedic(int id)
        {
            return true;
        }
    }
}
