using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelAgencyHelper.Models;
using FlexLabs.EntityFrameworkCore.Upsert;

namespace TravelAgencyHelper.Data
{
    public class SeedData
    {
        public static Route[] routes = new Route[]
            {
                    new Route() { Name = "Фанские горы", Price = 600, Deposit = 20, Category = "Трек" }, //identity can't be filled
                    new Route() { Name = "Сванетия", Price = 200, Deposit = 20, Category = "Трек"},
                    new Route() { Name = "Ликийская тропа", Price = 250, Deposit = 20, Category = "Трек" },
                    new Route() { Name = "Марокко + Тубкаль", Price = 250, Deposit = 20, Category = "Восхождение" },
                    new Route() { Name = "Кора вокруг Кайласа", Price = 250, Deposit = 20, Category = "Трек" },
                    new Route() { Name = "К Базовому лагерю Аннапурны", Price = 250, Deposit = 20, Category = "Трек" },
                    new Route() { Name = "Восхождение на Казбек", Price = 250, Deposit = 20, Category = "Восхождение" }
            };

        public static DaysInRoute[] daysInRoutes = new DaysInRoute[]
            {
                    new DaysInRoute() { DayBySequence = 1, Country = "Таджикистан", Description="Day one in Fany" },
                    new DaysInRoute() { DayBySequence = 2, Country = "Таджикистан", Description="Day two in Fany" },
                    new DaysInRoute() { DayBySequence = 1, Country = "Грузия", Description="Day one in Georgia" },
                    new DaysInRoute() { DayBySequence = 2, Country = "Грузия", Description="Day two in Georgia" }
            };
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TravelAgencyContext context = app.ApplicationServices.GetRequiredService<TravelAgencyContext>();
            context.Database.Migrate();

            foreach (Route route in routes)
            {
                 context.Routes.Upsert(route).On(r => r.Name).Run();
            }

            Route[] routeforDays = context.Routes.Take(2).ToArray();
            
            for (int i = 0; i < daysInRoutes.Length; i++)
            {

                daysInRoutes[i].RouteId = routeforDays[i / 2].Id;

                context.DaysInRoutes.Upsert(daysInRoutes[i]).On(d => new { d.RouteId, d.DayBySequence}).Run();
                

            }
        }
    }
}
