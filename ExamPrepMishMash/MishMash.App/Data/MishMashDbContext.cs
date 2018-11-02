using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MishMash.App.Models;

namespace MishMash.App.Data
{
    public class MishMashDbContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagsChannels> TagsChannelses { get; set; }
        public DbSet<UsersChannels> UsersChannelses { get; set; }

        public MishMashDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MishMashDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=MishMash;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>()
                .HasMany(x => x.Followers)
                .WithOne(x => x.Channel)
                .HasForeignKey(x => x.ChannelId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Channels)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Tag>()
                .HasMany(x => x.Channels)
                .WithOne(x => x.Tag)
                .HasForeignKey(x => x.TagId);

            modelBuilder.Entity<Channel>()
                .HasMany(x => x.Tags)
                .WithOne(x => x.Channel)
                .HasForeignKey(x => x.ChannelId);
        }
    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<MishMashDbContext>
    {
        public MishMashDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MishMashDbContext>();
            optionsBuilder.UseSqlServer(@"Server=WARGLAIVE\SQLEXPRESS;Database=MishMash;Integrated Security=true;");

            return new MishMashDbContext(optionsBuilder.Options);
        }
    }
}