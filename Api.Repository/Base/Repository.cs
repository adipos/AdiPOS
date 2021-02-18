using Api.Database.Base;
using Api.Database.Data;
using Api.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Base
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        public Repository(IUnitOfWork<ApiContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<ApiContext> UnitOfWork { get; }

        public EntityEntry Add(TEntity entity)
        {
            entity.LastModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = 0;
            entity.LastModifiedBy = 0;
            return UnitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public async Task<EntityEntry> AddAsync(TEntity entity)
        {
            entity.LastModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = 0;
            entity.LastModifiedBy = 0;
            return await UnitOfWork.Context.Set<TEntity>().AddAsync(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            UnitOfWork.Context.Set<TEntity>().AddRange(entities);
        }

        public EntityEntry Delete(TEntity entity)
        {
            return UnitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public EntityEntry Delete(object id)
        {
            TEntity entityToDelete = UnitOfWork.Context.Set<TEntity>().Find(id);
            if (entityToDelete != null)
                return Delete(entityToDelete);
            else
                return null;
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entityToDelete in entities)
            {
                Delete(entityToDelete);
            }
        }


        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = UnitOfWork.Context.Set<TEntity>();

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = UnitOfWork.Context.Set<TEntity>();

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public EntityEntry Update(TEntity entity)
        {
            entity.LastModifiedBy = 0;
            entity.LastModifiedOn = DateTime.Now;
            return UnitOfWork.Context.Set<TEntity>().Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            UnitOfWork.Context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
