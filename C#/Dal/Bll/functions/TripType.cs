using AutoMapper;
using Bll.Interfaces;
using Dto.Classes;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public class TripType : ITripType
    {
        private readonly Dal.Interfaces.ITripType tripTypeFromDal;
        private readonly IMapper mapper;
        //בנאי
        public TripType(Dal.Interfaces.ITripType tripTypeFromDal, IMapper mapper)
        {
            this.tripTypeFromDal = tripTypeFromDal;
            this.mapper = mapper; 
        }
       
        
        public async Task<int> AddAsync(Dto.Classes.TripType TripType)
        {
            List<Dal.Models.TripType> All =await tripTypeFromDal.GetAllAsync();
            var isExist=All.First(x=>x.TripName==TripType.TripName);
            if(isExist != null)
            {
                return -1;
            }
            Dal.Models.TripType mapTripType = mapper.Map<Dal.Models.TripType>(TripType);
            tripTypeFromDal.AddAsync(mapTripType);
            return TripType.Id;
        }

        public Task<bool> DeleteAsync(int id)
        {
           return tripTypeFromDal.DeleteAsync(id);
        }

        public async Task<List<Dto.Classes.TripType>> GetAllAsync()
        {
            return mapper.Map<List<Dto.Classes.TripType>>(await tripTypeFromDal.GetAllAsync());
        }
    }
}
