using System.Diagnostics;

namespace CodeApp.Models.DTOs
{
    public class CreateFoodDTO
    {
        public string name { get; set; }
        public DateTime expiryDate { get; set; }

        public List<LinkFoodToProduerDTO> producers { get; set; } = new();
    }
}
