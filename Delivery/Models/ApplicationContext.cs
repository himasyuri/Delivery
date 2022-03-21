using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Delivery.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Comment> Comments { get; set; }
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

            builder
                .Entity<Comment>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
