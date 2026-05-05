using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeApp.Models.Entities
{
    public class Producer
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string country { get; set; }

        [EmailAddress]
        public string email { get; set; }
        public List<FoodProducer> foodProducers { get; set; } = new();

    }
}
