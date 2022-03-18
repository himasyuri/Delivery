using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Delivery.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                 .Entity<Application>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();
        }
    }
}
