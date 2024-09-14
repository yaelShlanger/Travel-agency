using Dal.Interfaces;
using Dal.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class sereviceCollectionExtention
    {
        public static void addRepository(this IServiceCollection services)
        {
            services.AddScoped<Interfaces.ITripType, Functions.TripType>();
            services.AddScoped<Interfaces.ITrip, Functions.Trip>();
            services.AddScoped<Interfaces.IUser, Functions.User>();
            services.AddScoped<Interfaces.IOrderTicket, Functions.OrderTicket>();

            services.AddSingleton<TheOrganizedTourContext, TheOrganizedTourContext>();
        }

    }

}