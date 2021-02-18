using Api.Database.Base;
using Api.Database.Data;
using Api.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : EntityBase<TKey>;
        int Commit();
        Task<int> CommitAsync();
        void Rollback();        
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
