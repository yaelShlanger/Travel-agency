using AutoMapper;
using Dto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Classes
{
    public class OrganizedTripProfile : Profile 
    {
        public OrganizedTripProfile()
        {
            //המרה לסוגי טיולים
            CreateMap<Dal.Models.TripType, TripType>().ReverseMap();
            //המרה למשתמשים
            CreateMap<Dal.Models.User, User>().ReverseMap();
            //המרה לטיולים
            CreateMap<Dal.Models.Trip, Trip>().
                ForMember(dest=>dest.TypeName,opt=>opt.MapFrom(src=>src.TypeNavigation.TripName))
                .ForMember(dest => dest.needMedic, opt => opt.MapFrom(src=>true))
                   .ReverseMap();

            //המרה להזמנות כרטיסים
            CreateMap<Dal.Models.OrderTicket, OrderTicket>().
                   ForMember(dest => dest.fullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                   .ForMember(dest => dest.DateOfTrip, opt => opt.MapFrom(src => src.Trip.Date))
                    .ForMember(dest => dest.destination, opt => opt.MapFrom(src => src.Trip.Destination));
                    

            CreateMap<OrderTicket, Dal.Models.OrderTicket>();
        }


    }
}
