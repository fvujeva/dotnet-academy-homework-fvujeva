using System.Reflection;
using Library.FilipVujeva.Contracts.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Library.FilipVujeva.Data.Configurations
{
    public class ApplicationDbContext : IdentityDbContext<Person, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(x => x.Adress)
                .WithOne(y => y.Person).HasForeignKey<Person>(t => t.Id).IsRequired();
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
