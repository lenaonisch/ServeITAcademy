using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyHelper.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgencyHelper.Models
{
    public class EFRoutesRepository : EFGenericRepository<Route>, IRoutesRepository
    {
        public EFRoutesRepository(TravelAgencyContext context) : base (context)
        {
            
        }

        public IQueryable<Route> Routes(int pageSize, int page) => _context.Routes.Where(route => (bool)route.IsActive).Skip(page * pageSize).Take(pageSize);

        public IQueryable<DaysInRoute> DaysOfRoute(int routeID) => _context.DaysInRoutes.Where(day => day.Route.Id == routeID);

        public Route GetRouteWithDays(Func<Route, bool> predicate)
        {
            return GetRoutesWithDays(predicate).FirstOrDefault();
        }

        public IQueryable<Route> GetRoutesWithDays(Func<Route, bool> predicate)
        {
            IQueryable<Route> query = _context.Routes.AsNoTracking().Where(route => predicate(route) && (bool)route.IsActive);
            return query.Include(route => route.Days);
        }
    }
}
