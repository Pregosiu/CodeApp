using System.ComponentModel.DataAnnotations;

namespace CodeApp.Models.Entities
{
    public class ForecastSource
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

    }
}
