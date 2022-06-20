using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clean.Infrastructure.Persistence
{
    public class SQLDBContext : DbContext
    {
        public DbSet<Hero> Hero => Set<Hero>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V1G6OJJ;Database=cleandemo;Trusted_Connection=True;");
        }
    }
}