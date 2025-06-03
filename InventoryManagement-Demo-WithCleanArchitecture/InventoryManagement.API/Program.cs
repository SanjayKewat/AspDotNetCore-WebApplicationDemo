using InventoryManagement.API.Middleware;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure.Persistence;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;



var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("InventoryManagement.API")); // Pass the project name here, so that migartion file created under this project
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injection
builder.Services.AddScoped<IEquipmentInventoryRepository, EquipmentInventoryRepository>();
builder.Services.AddScoped<IEquipmentInventoryService, EquipmentInventoryService>();

var app = builder.Build();

// Use global error handling
app.UseErrorHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
