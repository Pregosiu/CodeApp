using System.ComponentModel.DataAnnotations;

namespace CodeApp.Models.DTOs
{
    public class FoodProducerCalorieDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive integer.")]
        public int id { get; set; }
        public string name { get; set; }
        public int calories { get; set; }
    }
}
