using IKnowTechnologyCase.CORE.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.DAL.DbContext
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
                  
            builder.Entity<AppUser>().Property(a => a.FullName).IsRequired();
            builder.Entity<Notebook>().Property(a => a.Title).IsRequired();            
            builder.Entity<AppUser>().HasMany(a => a.Notebooks).WithOne(a => a.User).HasForeignKey(b => b.UserId);
            base.OnModelCreating(builder);

        }
    }
}
