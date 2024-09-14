using AutoMapper;
using Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Bll.functions
{
    public class User : IUser
    {

        private readonly Dal.Interfaces.IUser userFromDal;
        private readonly IMapper mapper;
        //בנאי
        public User(Dal.Interfaces.IUser userFromDal, IMapper mapper)
        {
            this.userFromDal = userFromDal;
            this.mapper = mapper;
        }
        //הוספת משתמש
        public async Task<int> AddAsync(Dto.Classes.User user)
        {
            if (user.FirstName.Length == 0)
            {
                return -1;
            }
            userFromDal.AddAsync(mapper.Map<Dal.Models.User>(user));
            return user.Id;

        }
        public async Task<bool> DeleteAsync(int id)
        {
            List<Dal.Models.User> x = await userFromDal.GetAllAsync();
            Dal.Models.User user = x.FirstOrDefault(u=>u.Id==id);
            if (user==null || user.OrderTickets.Count>0) 
            {
                return false;
            }
            return await userFromDal.DeleteAsync(user.Id);    
        }
        public async Task<List<Dto.Classes.Trip>> GetAllTripsToUserAsync(int id)
        {
            List <Dal.Models.User> users = await userFromDal.GetAllAsync();
            Dal.Models.User user=users.FirstOrDefault(u=>u.Id==id);
            List<Dal.Models.Trip> trips = new List<Dal.Models.Trip>();
            user.OrderTickets.ToList().ForEach(t => { trips.Add(t.Trip); });
            List<Dto.Classes.Trip> dtotrips = mapper.Map<List<Dto.Classes.Trip>>(trips);
            return dtotrips;    
        }
        public async Task<bool> UpdateAsync(Dto.Classes.User user)
        {
            if(user.FirstName.Length==0)
            {
                return false;
            }
            return await userFromDal.UpdateAsync(mapper.Map<Dal.Models.User>(user));
        }
        public async Task<List<Dto.Classes.User>> GetAllAsync()
        {
            return mapper.Map<List<Dto.Classes.User>>(await userFromDal.GetAllAsync());
        }

        public async Task<Dto.Classes.User> GetByMailAndPasswordAsync(string mail, string password)
        {
            return mapper.Map<Dto.Classes.User>(await userFromDal.GetByMailAndPasswordAsync(mail, password));
        }
    }
}