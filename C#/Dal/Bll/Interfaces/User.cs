using Dto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByMailAndPasswordAsync(string mail, string password);
        Task<int> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<List<Trip>> GetAllTripsToUserAsync(int id);
    }
}
