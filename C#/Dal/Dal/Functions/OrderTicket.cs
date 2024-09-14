using Dal.Interfaces;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Functions
{
    public class OrderTicket : IOrderTicket
    {
        private TheOrganizedTourContext db;
        public OrderTicket(TheOrganizedTourContext db) { this.db = db; }    
        
        public async Task<int> AddOrderAsync(Models.OrderTicket OrderTicket)
        {
            db.OrderTickets.Add(OrderTicket);
            await db.SaveChangesAsync();
            return OrderTicket.Id;   
        }

        public async Task<bool> DeleteAsync(int id)
        { 
            var delete=await GetByIdAsync(id);
            if (delete != null)
            {
                db.OrderTickets.Remove(delete);
                await db.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public async Task<List<Models.OrderTicket>> GetAllAsync()
        {
            return await db.OrderTickets.Include(p=>p.Trip).Include(p=>p.User).ToListAsync();
        }

        public async Task<Models.OrderTicket> GetByIdAsync(int id)
        { 
            return await db.OrderTickets.Include(p => p.Trip).Include(p=>p.User).FirstOrDefaultAsync(p => p.Id == id);

        }
    }
}
