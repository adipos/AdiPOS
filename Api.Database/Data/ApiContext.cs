using Api.Database.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Data
{
    public class ApiContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            
        }
    }
}
