using System.Text;
using SendGrid;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Generators;
using Library.FilipVujeva.Contracts.Services;
using Library.FilipVujeva.Data.Configurations;
using Library.FilipVujeva.Services.Generators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Library.FilipVujeva.Contracts.Settings;

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

        public static void ConfigureEmailSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.Settings));
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library.FilipVujeva.Api", Version = "v1" });
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    },
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, new string[] { } },
                });
            });
        }
    }
}
