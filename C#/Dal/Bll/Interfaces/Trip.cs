using Dto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ITrip
    {
        Task<List<Trip>> GetAllAsync();
        Task<Trip> GetByIdAsync(int id);
        Task<int> AddAsync(Trip Trip);
        Task<bool> UpdateAsync(Trip Trip);
        Task<List<OrderTicket>> getInvitesToTripAsync(Trip trip);
    }
}
