using Microsoft.EntityFrameworkCore;
using ScientaScheduler.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScientaSchedurler.Application.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
            where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity)
        {
            using (ScientaContext context = new ScientaContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (ScientaContext context = new ScientaContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (ScientaContext context = new ScientaContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (ScientaContext context = new ScientaContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (ScientaContext context = new ScientaContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}