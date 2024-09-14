using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IOrderTicket
    {
        Task<List<OrderTicket>> GetAllAsync();
        Task<OrderTicket> GetByIdAsync(int id);
        Task<int> AddOrderAsync(OrderTicket OrderTicket);
        Task<bool> DeleteAsync(int id);
    }
}
