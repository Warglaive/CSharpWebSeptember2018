using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RunesApp.Models;

namespace RunesApp.Data
{
    public class RunesDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        public RunesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=RunesDB;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasKey(x => x.Id);

            modelBuilder.Entity<Album>()
                .HasMany(x => x.Tracks)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId);
        }
        public class BloggingContextFactory : IDesignTimeDbContextFactory<RunesDbContext>
        {
            public RunesDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<RunesDbContext>();
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=RunesDB;Trusted_Connection=true");

                return new RunesDbContext(optionsBuilder.Options);
            }
        }
    }
}