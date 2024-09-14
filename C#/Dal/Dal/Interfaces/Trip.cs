using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface ITrip
    {
        Task<List<Trip>> GetAllAsync();
        Task<Trip> GetByIdAsync(int id);
        Task<int> AddAsync(Trip Trip);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Trip Trip);
       
    }
}
