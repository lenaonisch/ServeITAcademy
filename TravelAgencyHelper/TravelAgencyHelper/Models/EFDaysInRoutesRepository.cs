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

        public bool SoftRemove(int id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                entity.IsActive = false;
                _context.Update(entity);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Update(DaysInRoute entity)
        {
            if (entity != null)
            {
                _context.Update(entity);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void Erase(int id)
        {
            throw new NotImplementedException();
        }
    }
}
