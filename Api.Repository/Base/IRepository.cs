using Api.Database.Base;
using Api.Database.Data;
using Api.Repository.UnitOfWork;
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
public interface IRepository<TEntity, TKey> where TEntity : IEntityBase<TKey>
    {
        IUnitOfWork<ApiContext> UnitOfWork { get; }
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        EntityEntry Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        Task<EntityEntry> AddAsync(TEntity entity);

        EntityEntry Delete(TEntity entity);
        EntityEntry Delete(object id);
        void Delete(IEnumerable<TEntity> entities);


        EntityEntry Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
    }
}
