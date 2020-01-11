using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyHelper.Data;

namespace TravelAgencyHelper.Models
{
    public class EFDaysInRoutesRepository : IGenericRepository<DaysInRoute>
    {
        TravelAgencyContext _context;

        public EFDaysInRoutesRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public IQueryable<DaysInRoute> Get()
        {
            return _context.DaysInRoutes;
        }
        public void Create(DaysInRoute entity)
        {
            _context.DaysInRoutes.Add(entity);
            _context.SaveChanges();
        }

        public DaysInRoute FindById(int id)
        {
            return _context.DaysInRoutes.FirstOrDefault(day => day.Id == id);
        }

        public IQueryable<DaysInRoute> Get(Func<DaysInRoute, bool> predicate)
        {
            return _context.DaysInRoutes.Where(day => predicate(day));
        }

        public void SoftRemove(DaysInRoute entity)
        {
            entity.IsActive = false;
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Update(DaysInRoute entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
