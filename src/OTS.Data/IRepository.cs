﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entities);

        TEntity GetById(object id);

        IQueryable<TEntity> GetAll();

        Task Update(TEntity entity, TEntity newEntity);

        Task Update(IEnumerable<TEntity> entities);

        void Remove(object id);

        void Remove(TEntity entity);

        void Remove(params TEntity[] entities);

        void Remove(IEnumerable<TEntity> entities);
    }
}
