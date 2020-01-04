using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyHelper.Models
{
    public interface ITravelAgencyRepository
    {
        IQueryable<Route> Routes { get; }
        IQueryable<DaysInRoute> DaysInRoutes { get; }
    }
}
