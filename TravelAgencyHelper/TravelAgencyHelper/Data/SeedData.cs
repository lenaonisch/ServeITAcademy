using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelAgencyHelper.Models;

namespace TravelAgencyHelper.Data
{
    public class SeedData
    {
        public static Route[] routes = new Route[]
            {
                    new Route() { Id = 1, Name = "Фанские горы", Price = 600, Deposit = 20 },
                    new Route() { Id = 2, Name = "Сванетия", Price = 200, Deposit = 20 },
                    new Route() { Id = 3, Name = "Ликийская тропа", Price = 250, Deposit = 20 }
            };

        public static DaysInRoute[] daysInRoutes = new DaysInRoute[]
            {
                    new DaysInRoute() { DayBySequence = 1, Country = "Таджикистан", Route = routes[0], Description="Day one in Fany" },
                    new DaysInRoute() { DayBySequence = 2, Country = "Таджикистан", Route = routes[0], Description="Day two in Fany" }
            };
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TravelAgencyContext context = app.ApplicationServices.GetRequiredService<TravelAgencyContext>();
            context.Database.Migrate();

            if (!context.Routes.AnyAsync().Result)
            {
                context.Routes.AddRange(routes);
            }

            context.SaveChanges();
        }
    }
}
