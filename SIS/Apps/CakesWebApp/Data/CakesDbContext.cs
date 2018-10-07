﻿using CakesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CakesWebApp.Data
{
    public class CakesDbContext : DbContext
    {
        public CakesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected CakesDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=CakesAppDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(x => x.Products)
                .WithOne(x => x.Order).HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(x => new
                {
                    x.OrderId,
                    x.ProductId
                });
        }
    }
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<CakesDbContext>
    {
        CakesDbContext IDesignTimeDbContextFactory<CakesDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CakesDbContext>();
            optionsBuilder.UseSqlServer<CakesDbContext>("Server = (localdb)\\mssqllocaldb; Database = MyDatabaseName; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new CakesDbContext(optionsBuilder.Options);
        }
    }
}