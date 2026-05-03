using CodeApp.Model;

namespace CodeApp.Services
{
    public static class Converter
    {
        public static WeatherForecastDTO ToDTO(WeatherForecast entity)
        {
            return new WeatherForecastDTO
            {
                Date = entity.Date,
                Summary = entity.Summary,
                TemperatureC = entity.TemperatureC
            };
        }

        public static WeatherForecast ToEntity(WeatherForecastDTO dto)
        {
            return new WeatherForecast
            {
                Date = dto.Date,
                Summary = dto.Summary,
                TemperatureC = dto.TemperatureC
            };
        }

    }
}
