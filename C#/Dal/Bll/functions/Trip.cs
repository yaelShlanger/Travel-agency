using AutoMapper;
using Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    internal class Trip : ITrip
    {
        private readonly Dal.Interfaces.ITrip tripsFromDal;
        private readonly IMapper mapper;
        //בנאי
        public Trip(Dal.Interfaces.ITrip tripsFromDal, IMapper mapper)
        {
            this.tripsFromDal = tripsFromDal;
            this.mapper = mapper;
        }
        public async Task<int> AddAsync(Dto.Classes.Trip Trip)
        {
            if(await isValid(Trip))
            {
                await tripsFromDal.AddAsync(mapper.Map<Dal.Models.Trip>(Trip));
                return Trip.Id;
            }
            return -1;
        }

        public async Task<List<Dto.Classes.Trip>> GetAllAsync()
        {
            List<Dto.Classes.Trip> dtoTrips=new List<Dto.Classes.Trip> ();
            List<Dal.Models.Trip> t = await tripsFromDal.GetAllAsync();
            foreach (var item in t)
            {
                dtoTrips.Add(mapper.Map<Dto.Classes.Trip>(item));
            }
            return dtoTrips;
        }

        public async Task<Dto.Classes.Trip> GetByIdAsync(int id)
        {
            return mapper.Map<Dto.Classes.Trip>(tripsFromDal.GetByIdAsync(id));
        }

        public async Task<List<Dto.Classes.OrderTicket>> getInvitesToTripAsync(Dto.Classes.Trip trip)
        {
            List<Dal.Models.Trip> d = await tripsFromDal.GetAllAsync();
            Dal.Models.Trip current = d.FirstOrDefault(p=>p.Id == trip.Id);
            return mapper.Map<List<Dto.Classes.OrderTicket>>(current.OrderTickets.ToList());
        }

        public async Task<bool> UpdateAsync(Dto.Classes.Trip Trip)
        {
            if(!await isValid(Trip) && DateTime.Today < Trip.Date)
            {
                return false;
            }
            return await tripsFromDal.UpdateAsync(mapper.Map<Dal.Models.Trip>(Trip));
        }
        public static async Task<bool> isValid(Dto.Classes.Trip Trip)
        {
            if (Trip.Date > DateTime.Today && Trip.Date < DateTime.Today.AddMonths(3)
               && Trip.Hours >= 3 && Trip.Hours <= 12
                 && Trip.Vacancys > 0
                   && Trip.Price < 100000 && Trip.Price > 0)
            {
                return true;
            }
            return false;
        }
    }
}
