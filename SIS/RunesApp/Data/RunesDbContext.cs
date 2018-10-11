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
        public DbSet<TrackAlbum> TrackAlbums { get; set; }

        public RunesDbContext(DbContextOptions options)
           : base(options)
        {
        }

        protected RunesDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=IRunesAppDB;Integrated Security=True;")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Album>().HasKey(x => x.Id);
            modelBuilder.Entity<Track>().HasKey(x => x.Id);
            
            modelBuilder.Entity<Track>().HasMany(x => x.Albums)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.TrackId);

            modelBuilder.Entity<TrackAlbum>().HasOne(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId);

            modelBuilder.Entity<TrackAlbum>().HasOne(x => x.Track)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.TrackId);

            modelBuilder.Entity<TrackAlbum>().HasKey(x => new
            {
                x.AlbumId,
                x.TrackId
            });
        }
    }
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<RunesDbContext>
    {
        RunesDbContext IDesignTimeDbContextFactory<RunesDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RunesDbContext>();
            optionsBuilder.UseSqlServer<RunesDbContext>("Server = (localdb)\\mssqllocaldb; Database = MyDatabaseName; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new RunesDbContext(optionsBuilder.Options);
        }
    }
}