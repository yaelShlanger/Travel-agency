
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ITripType
    {
        Task<List<Dto.Classes.TripType>> GetAllAsync();
        Task<int> AddAsync(Dto.Classes.TripType TripType);
        Task<bool> DeleteAsync(int id);
    }
}
