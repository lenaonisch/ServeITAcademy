using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyHelper.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgencyHelper.Models
{
    public class EFTravelAgencyRepository : ITravelAgencyRepository
    {
        private TravelAgencyContext _context;

        public EFTravelAgencyRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public IQueryable<Route> Routes => _context.Routes;

        public IQueryable<DaysInRoute> DaysInRoutes => _context.DaysInRoutes;

        public IQueryable<DaysInRoute> DaysOfRoute(int routeID) => _context.DaysInRoutes.Where(day => day.Route.Id == routeID);
    }
}
