using System.ComponentModel.DataAnnotations;

namespace CodeApp.Models.DTOs
{
    public class ProducerDetailsDTO
    {
        public string name { get; set; }

        public string country { get; set; }

        [EmailAddress]
        public string email { get; set; }
    }
}
