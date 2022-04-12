//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using Library.FilipVujeva.API;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Data.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<Library.FilipVujeva.Contracts.Services.IPeopleService, Library.FilipVujeva.Services.PeopleService>();
builder.Services.AddScoped<Library.FilipVujeva.Contracts.Services.ILibraryService, Library.FilipVujeva.Services.LibraryService>();
builder.Services.AddScoped<Library.FilipVujeva.Contracts.Services.IEmailService, Library.FilipVujeva.Services.EmailService>();
builder.Services.AddScoped<Library.FilipVujeva.Contracts.Services.ILibraryNotificationService, Library.FilipVujeva.Services.LibraryNotificationService>();

builder.Services.AddScoped<Library.FilipVujeva.Contracts.Repositories.IUnitOfWork, Library.FilipVujeva.Data.Db.Repositories.UnitOfWork>();

builder.Services.AddScoped<Library.FilipVujeva.Contracts.Repositories.IRepository<Person>, Library.FilipVujeva.Data.Db.Repositories.Repository<Person>>();
builder.Services.AddScoped<Library.FilipVujeva.Contracts.Repositories.IPersonRepository, Library.FilipVujeva.Data.Db.Repositories.PersonRepository>();

builder.Services.AddScoped<DbContext, ApplicationDbContext>();

builder.Services.AddScoped<IList<Person>, List<Person>>();

IoC.ConfigureDependencies(builder.Services, builder.Configuration);
IoC.ConfigureServicesDependencies(builder.Services, builder.Configuration);
IoC.ConfigureIdentityDependencies(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
