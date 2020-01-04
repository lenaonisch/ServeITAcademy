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

        public IQueryable<DaysInRoute> DaysInRoutes
        {
            get 
            {
                return SeedData.daysInRoutes.AsQueryable<DaysInRoute>(); 
            }
        }
    }
}
