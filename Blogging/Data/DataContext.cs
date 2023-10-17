using Blogging.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasMany(b => b.Tags)
                .WithMany(b => b.Posts)
                .UsingEntity("BlogPostTag");
        }
    }
}
