using CodeApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Data
{
    public class AppDBContext : DbContext
    {
        
        public DbSet<Producer> Producers{ get; set;}
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodProducer> FoodProducers { get; set; }




        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodProducer>()
                .HasKey(fp => new { fp.foodId, fp.producerId });

            modelBuilder.Entity<FoodProducer>()
                .HasOne(fp => fp.food)
                .WithMany(f => f.foodProducers)
                .HasForeignKey(fp => fp.foodId);

            modelBuilder.Entity<FoodProducer>()
                .HasOne(fp => fp.producer)
                .WithMany(p => p.foodProducers)
                .HasForeignKey(fp => fp.producerId);

        }
    }
}
