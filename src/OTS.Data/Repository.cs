using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OTS.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly OTsystemDB _dbContext;
        public DbSet<TEntity> Entities { get; }
        public Repository(OTsystemDB dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity GetById(object id)
        {
            var found = Entities.Find(id) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.UserNotFound);
            return found;
        }

        public void Remove(object id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
        }

        public void Remove(params TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.RemoveRange(entities);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.RemoveRange(entities);
        }

        public async Task Update(TEntity entity, TEntity newEntity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //Entities.Update(entity);

            var entry = Entities.Entry(entity);
            entry.CurrentValues.SetValues(newEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
