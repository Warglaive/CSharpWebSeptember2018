using CakesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CakesApp.Data
{
    public class CakesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public CakesDbContext()
        {
            
        }

        public CakesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=Cakes;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }

        public class BloggingContextFactory : IDesignTimeDbContextFactory<CakesDbContext>
        {
            public CakesDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CakesDbContext>();
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=Cakes;Integrated Security=true");

                return new CakesDbContext(optionsBuilder.Options);
            }
        }
    }
}