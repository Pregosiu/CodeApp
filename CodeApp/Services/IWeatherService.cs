using CodeApp.Models.DTO;

namespace CodeApp.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecastDTO>> GetAllForecastsAsync();
        Task CreateForecastAsync(WeatherForecastDTO forecast);
    }
}
