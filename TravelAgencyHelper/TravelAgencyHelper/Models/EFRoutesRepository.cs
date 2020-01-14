using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyHelper.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgencyHelper.Models
{
    public class EFRoutesRepository : IRoutesRepository
    {
        private TravelAgencyContext _context;

        public EFRoutesRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public IQueryable<Route> GetAll() => _context.Routes.Where(route => (bool)route.IsActive);
        
        public IQueryable<Route> Routes(int pageSize, int page) => _context.Routes.Where(route => (bool)route.IsActive).Skip(page * pageSize).Take(pageSize);

        public IQueryable<DaysInRoute> DaysOfRoute(int routeID) => _context.DaysInRoutes.Where(day => day.Route.Id == routeID);

        public IQueryable<Route> Get()
        {
            return _context.Routes.Where(route => (bool)route.IsActive);
        }

        public IQueryable<Route> Get(Route partialRoute)
        {
            var properties = typeof(Route).GetProperties();
            return _context.Routes.Where(route => properties.Any(prop => prop.GetValue(route, null) == prop.GetValue(partialRoute)/* && (bool)route.IsActive*/));
        }

        public IQueryable<Route> Get(Func<Route, bool> predicate)
        {
            return _context.Routes.Where(route => predicate(route) && (bool)route.IsActive);
        }

        public Route FindById(int id)
        {
            return _context.Routes.Where(t => t.Id == id && (bool)t.IsActive).FirstOrDefault();
        }

        public void Create(Route entity)
        {
            _context.Routes.Add(entity);
            _context.SaveChanges();
        }

        public bool Update(Route entity)
        {
            
            if (entity != null)
            {
                var _entry = _context.Entry<Route>(entity);
                _context.Routes.Attach(entity);
                _entry.State = EntityState.Modified;



                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool SoftRemove(int id)
        {
            Route entity = FindById(id);
            
            entity.IsActive = false;

            if (entity != null)
            {
                var _entry = _context.Entry<Route>(entity);
                
                _context.Routes.Attach(entity);
                _entry.State = EntityState.Modified;



                _context.SaveChanges();

                return true;
            }

            return false;
        }

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
