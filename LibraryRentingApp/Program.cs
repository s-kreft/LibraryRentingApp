global using LibraryRentingApp.Controllers;
global using LibraryRentingApp.Services;
global using LibraryRentingApp.Repository;
global using LibraryRentingApp.Models;
global using Microsoft.EntityFrameworkCore;
global using System.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryRentingDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), null)
            .LogTo((arg) => Debug.WriteLine(arg), LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors(
));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILibraryRentingService, LibraryRentingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
