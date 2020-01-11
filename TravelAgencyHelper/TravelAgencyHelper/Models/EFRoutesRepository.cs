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

        public IQueryable<Route> GetAll() => _context.Routes;
        
        public IQueryable<Route> Routes(int pageSize, int page) => _context.Routes.Skip(page * pageSize).Take(pageSize);

        public IQueryable<DaysInRoute> DaysOfRoute(int routeID) => _context.DaysInRoutes.Where(day => day.Route.Id == routeID);

        public IQueryable<Route> Get()
        {
            return _context.Routes;
        }

        public IQueryable<Route> Get(Func<Route, bool> predicate)
        {
            return _context.Routes.Where(route => predicate(route));
        }

        public Route FindById(int id)
        {
            return _context.Routes.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Create(Route entity)
        {
            _context.Routes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Route entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void SoftRemove(Route entity)
        {
            entity.IsActive = false;
            _context.Update(entity);
            _context.SaveChanges();
        }

        public Route GetRouteWithDays(Func<Route, bool> predicate)
        {
            return GetRoutesWithDays(predicate).FirstOrDefault();
        }

        public IQueryable<Route> GetRoutesWithDays(Func<Route, bool> predicate)
        {
            IQueryable<Route> query = _context.Routes.AsNoTracking().Where(route => predicate(route));
            return query.Include(route => route.Days);
        }
    }
}
