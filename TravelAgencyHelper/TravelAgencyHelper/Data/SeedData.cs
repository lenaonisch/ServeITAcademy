using System;
using System.Linq;
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
                    new DaysInRoute() { DayBySequence = 2, Country = "Таджикистан", Description="Day two in Fany" }
            };
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TravelAgencyContext context = app.ApplicationServices.GetRequiredService<TravelAgencyContext>();
            context.Database.Migrate();

            context.RemoveRange(context.Routes);
            //if (!context.Routes.Any<Route>())
            //{
                context.Routes.AddRange(routes);
            //}
            Route route1 = context.Routes.FirstOrDefault(route => route.Name == routes[0].Name);
            daysInRoutes[0].Route = route1;
            daysInRoutes[1].Route = route1;
            context.RemoveRange(context.DaysInRoutes);
            //if (!context.DaysInRoutes.Any<DaysInRoute>())
            //{
            context.DaysInRoutes.AddRange(daysInRoutes);
            //}

            context.SaveChanges();
        }
    }
}
