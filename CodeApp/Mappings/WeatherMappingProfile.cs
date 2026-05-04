using AutoMapper;
using CodeApp.Models.DTO;
using CodeApp.Models.Entities;

namespace CodeApp.Mappings
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDTO>();
            CreateMap<WeatherForecastDTO, WeatherForecast>();
        }

    }
}
