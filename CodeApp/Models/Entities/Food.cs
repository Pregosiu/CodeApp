using System.ComponentModel.DataAnnotations;

namespace CodeApp.Models.Entities
{
    
    public class Food
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public DateTime expiryDate { get; set; }
        public List<FoodProducer> foodProducers { get; set; } = new();


    }
}
