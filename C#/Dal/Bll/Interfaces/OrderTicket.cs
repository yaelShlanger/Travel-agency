using Dto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IOrderTicket
    {
        Task<List<OrderTicket>> GetAllToTripAsync(int id);
        Task<List<OrderTicket>> GetAllAsync();
        Task<int> AddOrderAsync(OrderTicket orderTicket);
        Task<bool> DeleteAsync(int id);

    }
}
