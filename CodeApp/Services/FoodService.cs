using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeApp.Data;
using CodeApp.Models.DTOs;
using CodeApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Services
{
    public class FoodService : IFoodService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public FoodService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoodDTO>> GetAllFoodsAsync()
        {
            return await _dbContext.Foods.ProjectTo<FoodDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<FoodDetailsDTO> GetFoodsCaloriesAsync(int foodId)
        {
           var food = await _dbContext.Foods.Where(f => f.id == foodId).Include(f => f.foodProducers).ThenInclude(fp => fp.producer).FirstOrDefaultAsync();

           return _mapper.Map<FoodDetailsDTO>(food);
        }



        public async Task CreateFoodAsync(CreateFoodDTO food)
        {
            _dbContext.Foods.Add(_mapper.Map<Food>(food));
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task CreateProducerAsync(ProducerDTO producer)
        {
            _dbContext.Producers.Add(_mapper.Map<Producer>(producer));
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task LinkFoodToProducerAsync(int foodId, LinkFoodToProduerDTO linkFoodToProduerDTO)
        {
            var food = await _dbContext.Foods.FirstOrDefaultAsync(f => f.id == foodId);
            food.foodProducers.Add(_mapper.Map<FoodProducer>(linkFoodToProduerDTO));
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task LinkProducerToFoodAsync(int producerId, LinkProducerToFoodDTO linkProducerToFoodDTO)
        {
            var producer = await _dbContext.Producers.FirstOrDefaultAsync(p => p.id == producerId);
            producer.foodProducers.Add(_mapper.Map<FoodProducer>(linkProducerToFoodDTO));
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
