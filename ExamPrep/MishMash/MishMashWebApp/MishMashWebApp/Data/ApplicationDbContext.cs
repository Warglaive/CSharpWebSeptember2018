using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<UsersChannels> UsersChannels { get; set; }

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
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=MishMashDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersChannels>()
                .HasKey(x => new
                {
                    x.UserId,
                    x.ChannelId
                });
            modelBuilder.Entity<UsersChannels>().HasOne(x => x.User)
                .WithMany(x => x.FollowedChannels).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersChannels>().HasOne(x => x.Channel)
                .WithMany(x => x.Followers).OnDelete(DeleteBehavior.Cascade);
        }
    }
}