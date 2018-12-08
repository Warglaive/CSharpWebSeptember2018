using Microsoft.EntityFrameworkCore;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Data
{
    public class TorshiaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Sector> AffectedSectors { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public TorshiaDbContext(DbContextOptions options) : base(options)
        {
        }

        public TorshiaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=TorshiaDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}