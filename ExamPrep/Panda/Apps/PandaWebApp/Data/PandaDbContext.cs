using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models;

namespace PandaWebApp.Data
{
    public class PandaDbContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext(DbContextOptions options) : base(options)
        {
        }

        public PandaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=PandaDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One package => one receips, one receipt => one package
            //one user => many packages
            //one package => one user

            //modelBuilder.Entity<Package>()
            //    .HasOne(x => x.Receipt)
            //    .WithOne(x => x.Package)
            //    .HasForeignKey<Package>(x => x.ReceiptId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Packages)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}