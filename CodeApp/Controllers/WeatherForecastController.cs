using CodeApp.Model;
using CodeApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CodeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public WeatherForecastController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var a = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            return a;
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public IActionResult Post(WeatherForecastDTO forecast) { 
            if (forecast == null)
            {
                return BadRequest("Forecast data is required.");
            }
            var entity = Converter.ToEntity(forecast);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return Ok(forecast);
        }
    }
}
