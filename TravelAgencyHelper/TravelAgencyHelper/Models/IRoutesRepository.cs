using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyHelper.Models
{
    public interface IRoutesRepository : IGenericRepository<Route>
    {
        IQueryable<Route> GetAll();
        Route GetRouteWithDays(Func<Route, bool> route);
        IQueryable<Route> GetRoutesWithDays(Func<Route, bool> route);
        IQueryable<Route> Get(Route partialRoute);
        IQueryable<string> GetCountries(int routeId);
    }
}
