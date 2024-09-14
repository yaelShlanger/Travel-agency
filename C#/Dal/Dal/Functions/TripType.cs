using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interfaces;

namespace Dal.Functions
{
    public class TripType : ITripType
    {

        private TheOrganizedTourContext db;
        public TripType(TheOrganizedTourContext db) 
        {
            this.db = db; 
        }

        public async Task<int> AddAsync(Models.TripType TripType)
        {
            db.TripTypes.Add(TripType);
            db.SaveChangesAsync();
            return TripType.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await GetByIdAsync(id);
            if (delete != null)
            {
                db.TripTypes.Remove(delete);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Models.TripType>> GetAllAsync()
        {
            return await db.TripTypes.Include(p => p.Trips).ToListAsync();
        }

        public async Task<Models.TripType> GetByIdAsync(int id)
        {
            return await db.TripTypes.Include(p => p.Trips).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
