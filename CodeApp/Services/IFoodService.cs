using CodeApp.Models.DTOs;

namespace CodeApp.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDTO>> GetAllFoodsAsync();
        Task<FoodDetailsDTO> GetFoodsCaloriesAsync(int foodId);
        Task CreateFoodAsync(CreateFoodDTO food);
        Task CreateProducerAsync(ProducerDTO producer);
        Task LinkFoodToProducerAsync(int foodId, LinkFoodToProduerDTO linkFoodToProduerDTO);
        Task LinkProducerToFoodAsync(int producerId, LinkProducerToFoodDTO linkProducerToFoodDTO);
    }
}
