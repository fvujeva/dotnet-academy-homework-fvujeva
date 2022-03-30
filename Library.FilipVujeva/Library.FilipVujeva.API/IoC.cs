using System.Text;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Generators;
using Library.FilipVujeva.Data.Configurations;
using Library.FilipVujeva.Services.Generators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
                    configuration.GetConnectionString("PersonDB"),
                    opt => opt.MigrationsAssembly("Library.FilipVujeva.Data.Db"));
            });
        }

        public static void ConfigureServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(
                configuration.GetSection("JWT"));

            services.AddScoped<Contracts.Services.IRegistrationService, Services.RegistrationService>();
            services.AddScoped<Contracts.Services.IAuthenticationService, Services.AuthenticationService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }

        public static void ConfigureIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Person, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                };
            });
        }
    }
}
