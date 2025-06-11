using Microsoft.EntityFrameworkCore;
using URLShortener.Domain.Models;

namespace URLShortener.Database
{
    public class UrlShortenerDbContext : DbContext 
    {
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options) { }
        
        public DbSet<UrlMapping> UrlMappings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlMapping>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.ShortenedUrl).IsUnique();
                entity.Property(u => u.ShortenedUrl)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
