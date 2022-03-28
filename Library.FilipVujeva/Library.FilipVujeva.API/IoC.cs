using Library.FilipVujeva.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.FilipVujeva.API
{
    public static class IoC
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
            opt =>
            {
                opt.UseSqlServer(
                    configuration.GetConnectionString("LibraryDB"),
                    opt => opt.MigrationsAssembly("Library.FilipVujeva.Data.Db"));
            });
        }
    }
}
