﻿using System;
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
        long Create(TEntity entity);
        bool Update(TEntity entity);
        bool SoftRemove(int id);
        void Erase(int id);
    }
}
