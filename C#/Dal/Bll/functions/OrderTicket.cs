using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public class OrderTicket : Interfaces.IOrderTicket
    {
        private readonly Dal.Interfaces.IOrderTicket ordersFromDal;
        private readonly Dal.Interfaces.ITrip tripsFromDal;
        private readonly IMapper mapper;
        //בנאי
        public OrderTicket(Dal.Interfaces.IOrderTicket ordersFromDal, IMapper mapper, Dal.Interfaces.ITrip tripsFromDal)
        {
            this.ordersFromDal = ordersFromDal;
            this.tripsFromDal = tripsFromDal;
            this.mapper = mapper;
        }
        public async Task<int> AddOrderAsync(Dto.Classes.OrderTicket orderTicket)
        {
            Dal.Models.OrderTicket newTypeDal =mapper.Map<Dal.Models.OrderTicket>(orderTicket);

            Dal.Models.Trip t1 = await tripsFromDal.GetByIdAsync((int)orderTicket.TripId);
            t1.Vacancys -= orderTicket.Tickets;
            await tripsFromDal.UpdateAsync(t1);

            //להחזיר בדיקות תקינות
            newTypeDal.Date = DateTime.Today;
            newTypeDal.OrderTime =new TimeSpan(DateTime.Now.Hour);
           
         
            return await ordersFromDal.AddOrderAsync(newTypeDal);
           /*
            return orderTicket.Id;*/
        }

        public async Task<bool> DeleteAsync(int id)
        {
            List<Dal.Models.OrderTicket> toDelete =await ordersFromDal.GetAllAsync();
            Dto.Classes.OrderTicket current = mapper.Map<Dto.Classes.OrderTicket>(toDelete.FirstOrDefault(x => x.Id == id));
            if (current.DateOfTrip > DateTime.Today)
            {
                Dal.Models.Trip myTrip=await tripsFromDal.GetByIdAsync((int)current.TripId);
                myTrip.Vacancys += current.Tickets;
                await tripsFromDal.UpdateAsync(myTrip);
                return await ordersFromDal.DeleteAsync(id);
            }
            return false;
        }


        public async Task<List<Dto.Classes.OrderTicket>> GetAllToTripAsync(int id)
        {
                List<Dal.Models.OrderTicket> all=await ordersFromDal.GetAllAsync();
                return mapper.Map<List<Dto.Classes.OrderTicket>>(all.Select(x => x.TripId == id).ToList()); 
        }

        public async Task<List<Dto.Classes.OrderTicket>> GetAllAsync()
        {
               return mapper.Map<List<Dto.Classes.OrderTicket>>(await ordersFromDal.GetAllAsync());
        }
    }
}
