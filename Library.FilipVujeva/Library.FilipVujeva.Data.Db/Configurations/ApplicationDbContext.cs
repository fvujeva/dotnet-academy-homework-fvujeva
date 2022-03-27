using System.Reflection;
using Library.FilipVujeva.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
namespace Library.FilipVujeva.Data.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; } = default!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
