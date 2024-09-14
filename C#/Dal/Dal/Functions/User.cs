using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Functions
{
    public class User : Interfaces.IUser
    {
        private TheOrganizedTourContext db;
        public User(TheOrganizedTourContext db) { this.db = db; }

        public async Task<int> AddAsync(Models.User user)
        {
            db.Users.Add(user);
            db.SaveChangesAsync();
            return  user.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var delete = db.Users.FirstOrDefault(p=>p.Id==id);
            if (delete != null)
            {
                db.Users.Remove(delete);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<Models.User>> GetAllAsync()
        {
            return await db.Users.Include(p=>p.OrderTickets).ThenInclude(t=>t.Trip).ToListAsync();
        }

        public async Task<Models.User> GetByMailAndPasswordAsync(string mail, string password)
        {
            return await db.Users.Include(p => p.OrderTickets).FirstOrDefaultAsync(m => m.Mail == mail && m.Password == password);
        }

        public async Task<bool> UpdateAsync(Models.User user)
        {
            var current = this.db.Users.SingleOrDefault(p => p.Id == user.Id);
            if (current != null)
            {
                db.Entry(current).CurrentValues.SetValues(user);
                db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
