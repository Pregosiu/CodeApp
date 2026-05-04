using CodeApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Data
{
    public class AppDBContext : DbContext
    {
        
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }



        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

     
    }
}
