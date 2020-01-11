using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyHelper.Models
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity FindById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void SoftRemove(TEntity entity);
    }
}
