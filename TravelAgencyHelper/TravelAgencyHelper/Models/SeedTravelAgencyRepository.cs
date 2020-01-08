using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgencyHelper.Data;

namespace TravelAgencyHelper.Models
{
    public class SeedTravelAgencyRepository : ITravelAgencyRepository
    {
        public IQueryable<Route> Routes
        {
            get
            {
                return SeedData.routes.AsQueryable<Route>();
            }
        }

        public IQueryable<DaysInRoute> DaysInRoutes => SeedData.daysInRoutes.AsQueryable<DaysInRoute>();

        public IQueryable<DaysInRoute> DaysOfRoute(int routeID)
        {
            return SeedData.daysInRoutes.Where(day => day.Route.Id == routeID).AsQueryable<DaysInRoute>();
        }
    }
}
