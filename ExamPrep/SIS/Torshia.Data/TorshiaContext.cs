using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Torshia.Models;

namespace Torshia.Data
{
    public class TorshiaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<AffectedSectors> AffectedSectorses { get; set; }

        public TorshiaContext(DbContextOptions options)
            : base(options)
        {
        }

        public TorshiaContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WARGLAIVE\\SQLEXPRESS;Database=Torshia;Integrated Security=true");
            }
        }
        public class BloggingContextFactory : IDesignTimeDbContextFactory<TorshiaContext>
        {
            public TorshiaContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TorshiaContext>();
                optionsBuilder.UseSqlServer("Server=WARGLAIVE\\SQLEXPRESS;Database=Torshia;Integrated Security=true");

                return new TorshiaContext(optionsBuilder.Options);
            }
        }
    }
}