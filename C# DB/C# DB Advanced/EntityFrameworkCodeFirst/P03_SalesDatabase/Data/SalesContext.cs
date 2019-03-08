namespace P03_SalesDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Configuration.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureProductEntity(builder);

            ConfigureCustomerEntity(builder);

            ConfigureStoreEntity(builder);

            ConfigureSaleEntitiy(builder);
        }

        private void ConfigureSaleEntitiy(ModelBuilder builder)
        {
            builder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            builder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void ConfigureStoreEntity(ModelBuilder builder)
        {
            builder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            builder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            builder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);
        }

        private void ConfigureCustomerEntity(ModelBuilder builder)
        {
            builder
                .Entity<Customer>()
                .HasKey(c => c.CustomerId);

            builder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);

            builder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(c => c.Customer);
        }

        private void ConfigureProductEntity(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            builder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250);

            builder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue("No description");

            builder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Product);
        }
    }
}
