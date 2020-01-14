using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyHelper.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgencyHelper.Models
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class, IEntity, new()
    {
        protected TravelAgencyContext _context;
        protected DbSet<TEntity> _dbSet;

        public EFGenericRepository(TravelAgencyContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => _dbSet.Where(entity => (bool)entity.IsActive);
       

        public IQueryable<TEntity> Get()
        {
            return _dbSet.Where(entity => (bool)entity.IsActive);
        }

        public IQueryable<Route> Get(Route partialRoute)
        {
            var properties = typeof(Route).GetProperties();
            return _context.Routes.Where(route => properties.Any(prop => prop.GetValue(route, null) == prop.GetValue(partialRoute)/* && (bool)route.IsActive*/));
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(entity => predicate(entity) && (bool)entity.IsActive);
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Where(t => t.Id == id && (bool)t.IsActive).FirstOrDefault();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public bool Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entry = _context.Entry<TEntity>(entity);
                _dbSet.Attach(entity);
                _entry.State = EntityState.Modified;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool SoftRemove(int id)
        {
            TEntity entity = FindById(id);

            entity.IsActive = false;

            if (entity != null)
            {
                var _entry = _context.Entry<TEntity>(entity);

                _dbSet.Attach(entity);
                _entry.State = EntityState.Modified;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public void Erase(int id)
        {
            TEntity entity = new TEntity() { Id = id };
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
