using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeApp.Data;
using CodeApp.Models.DTO;
using CodeApp.Models.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public WeatherService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 

        public Task CreateForecastAsync(WeatherForecastDTO forecast)
        {
            _context.WeatherForecasts.Add(_mapper.Map<WeatherForecast>(forecast));
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<WeatherForecastDTO>> GetAllForecastsAsync()
        {
            return _context.WeatherForecasts.ProjectTo<WeatherForecastDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
