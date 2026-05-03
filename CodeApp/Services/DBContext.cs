using Microsoft.EntityFrameworkCore;

namespace CodeApp.Services
{
    public class DBContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }


    }
}
