using AdiPos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdiPos.Data
{
    public class ApiContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=209.145.50.68;Database=TestAdiPos;User ID=sa;Password=Pass@word;");
        }
    }
}
