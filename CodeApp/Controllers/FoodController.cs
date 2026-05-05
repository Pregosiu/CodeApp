using CodeApp.Models.DTOs;
using CodeApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using System.Data;

namespace CodeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("/food", Name = "GetFoods")]
        public async Task<ActionResult<IEnumerable<FoodDTO>>> Get()
        {

            var forecasts = await _foodService.GetAllFoodsAsync();
            return Ok(forecasts);
        }

        [HttpGet("/calories/{id}", Name = "FoodCalories")]
        public async Task<ActionResult<FoodDetailsDTO>> GetFoodsCalories(int id)
        {
            var foodDetails = await _foodService.GetFoodsCaloriesAsync(id);
            return Ok(foodDetails);
        }

        [HttpPost(Name = "PostFood")]
        public async Task<IActionResult> Post(CreateFoodDTO food)
        {
            if (food == null)
            {
                return BadRequest("Food data is required.");
            }
            await _foodService.CreateFoodAsync(food);

            return Ok("Food created");
        }

        [HttpPost("/producer", Name = "PostProducer")]
        public async Task<IActionResult> PostProducer(ProducerDTO producer)
        {
            if (producer == null)
            {
                return BadRequest("Producer data is required.");
            }
            await _foodService.CreateProducerAsync(producer);
            return Ok("Producer created");

        }

        [HttpPost("/food/{foodId}/link", Name = "LinkFoodToProducer")]
        public async Task<IActionResult> LinkFoodToProducer(int foodId, [FromBody] LinkFoodToProduerDTO lftp)
        {
            await _foodService.LinkFoodToProducerAsync(foodId, lftp);

            return Ok("Food linked to producer");

        }

        [HttpPost("/producer/{producerId}/link", Name = "LinkProducerToFood")]
        public async Task<IActionResult> LinkProducerToFood(int producerId, [FromBody] LinkProducerToFoodDTO lftp)
        {
            await _foodService.LinkProducerToFoodAsync(producerId, lftp);

            return Ok("Producer linked to food");
        }
    }
}
