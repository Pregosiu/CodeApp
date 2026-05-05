using CodeApp.Models.Entities;

namespace CodeApp.Models.DTOs
{
    public class FoodDetailsDTO
    {
        public string name { get; set; }
        public DateTime expiryDate { get; set; }
        public List<LinkFoodToProduerDTO> producers { get; set; } = new();
    }
}
