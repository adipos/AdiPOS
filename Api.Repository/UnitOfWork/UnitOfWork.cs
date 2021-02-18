using Api.Database.Base;
using Api.Database.Data;
using Api.Database.Entity;
using Api.Repository.Base;
using Api.Repository.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

using System.Threading.Tasks;
using static Api.Common.Constant;
//prueba
namespace Api.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork<ApiContext>
    {
        public ApiContext Context => Scope.ServiceProvider.GetRequiredService<ApiContext>();


        private readonly IServiceScope Scope;
        private readonly UserManager<ApplicationUser> _userManager;
        public UnitOfWork(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            Scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            _userManager = userManager;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : EntityBase<TKey>
        {
            var repository = new Repository<TEntity, TKey>(this);
            return repository;
        }

        public void Rollback()
        {
            Context.Dispose();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
