namespace CarDealer.Data
{
    using CarDealer.Models;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public CarDealerContext()
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarDealer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(entity =>
            {
                entity.HasKey(k => new { k.CarId, k.PartId });

                entity
                    .HasOne(p => p.Part)
                    .WithMany(c => c.PartCars)
                    .HasForeignKey(pc => pc.PartId);

                entity
                    .HasOne(c => c.Car)
                    .WithMany(p => p.PartCars)
                    .HasForeignKey(pc => pc.CarId);
            });
        }
    }
}
