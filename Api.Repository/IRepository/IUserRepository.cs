using Api.Database.Entity;
using Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser, string>
    {        
    }
}
