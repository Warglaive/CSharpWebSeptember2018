using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }
        public DbSet<Tag> Tags { get; set; }

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
            modelBuilder.Entity<UserChannel>()
                .HasKey(x => new
                {
                    x.ChannelId,
                    x.UserId
                });
            modelBuilder.Entity<UserChannel>().HasOne(x => x.Channel)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserChannel>().HasOne(x => x.User)
                .WithMany(x => x.FollowedChannels)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<Channel>()
            //    .HasMany(x => x.Followers)
            //    .WithOne(x => x.Channel)
            //    .HasForeignKey(x => x.ChannelId);

            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.FollowedChannels)
            //    .WithOne(x => x.User)
            //    .HasForeignKey(x => x.UserId);
        }
    }
}