using Library.FilipVujeva.Contracts.Repositories;
using Library.FilipVujeva.Contracts.Services;
using Library.FilipVujeva.Data.Db.Repositories;
using Library.FilipVujeva.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Library.FilipVujeva.Functions.Startup))]
namespace Library.FilipVujeva.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ILibraryNotificationService, LibraryNotificationService>();
        }
    }
}
