
using AutoMapper;
using Dal;
using Dal.Interfaces;
using Dto.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class serviceCollectionExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            //dal זימון של פונקציית ההרחבה מה
            services.addRepository();
            //טיפול בהזרקות של שכבה זו
            services.AddScoped<Interfaces.ITripType, functions.TripType>();
            services.AddScoped<Interfaces.ITrip, functions.Trip>();
            services.AddScoped<Interfaces.IUser, functions.User>();
            services.AddScoped<Interfaces.IOrderTicket, functions.OrderTicket>();

            //הוספת המרה אוטומטית
            services.AddAutoMapper(typeof(Dto.Classes.OrganizedTripProfile));
        }
    }
}
