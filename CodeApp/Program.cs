using CodeApp.Data;
using CodeApp.Mappings;
using CodeApp.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("connString") ??
    throw new InvalidOperationException("Conn string 'connString'" + " not found.");

builder.Services.AddDbContext<AppDBContext>(options => 
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<FoodProfile>());

builder.Services.AddScoped<IFoodService, FoodService>();

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
