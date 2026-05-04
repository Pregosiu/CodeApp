using CodeApp.Models.DTO;
using CodeApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using System.Data;

namespace CodeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecastDTO>>> Get(){   

            var forecasts = await _weatherService.GetAllForecastsAsync();
            return Ok(forecasts);
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public async Task<IActionResult> Post(WeatherForecastDTO forecast) { 
            if (forecast == null)
            {
                return BadRequest("Forecast data is required.");
            }
            await _weatherService.CreateForecastAsync(forecast);

            return Ok();
        }
    }
}
