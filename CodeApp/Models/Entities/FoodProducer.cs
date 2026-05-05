namespace CodeApp.Models.Entities
{
    public class FoodProducer
    {
        public int foodId { get; set; }
        public Food food { get; set; }
        public int producerId { get; set; }
        public Producer producer { get; set; }

        public int calories { get; set; }

    }
}
