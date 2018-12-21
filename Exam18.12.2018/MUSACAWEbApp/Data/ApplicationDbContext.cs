using Microsoft.EntityFrameworkCore;
using MUSACAWEbApp.Models;

namespace MUSACAWEbApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-941AUSN\SQLEXPRESS;Database=MusacaExamDb;Integrated Security=true;");
            }
        }
    }
}