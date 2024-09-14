using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface ITripType
    {
        Task<List<TripType>> GetAllAsync();
        Task<TripType> GetByIdAsync(int id);
        Task<int> AddAsync(TripType TripType);
        Task<bool> DeleteAsync(int id);
    }
}
