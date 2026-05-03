using CodeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Services
{
    public class AppDBContext : DbContext
    {
        
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

     
    }
}
