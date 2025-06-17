using Microsoft.EntityFrameworkCore;
using Publisher.Domain.Models;

namespace Publisher.Data.Data
{
    public class PublisherDbContext : DbContext
    {
        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Cover> Covers => Set<Cover>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<ArtistCover> ArtistCovers => Set<ArtistCover>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistCover>()
                .HasKey(ac => new { ac.ArtistId, ac.CoverId });

            modelBuilder.Entity<ArtistCover>()
                .HasOne(ac => ac.Artist)
                .WithMany(a => a.ArtistLinks)
                .HasForeignKey(ac => ac.ArtistId);

            modelBuilder.Entity<ArtistCover>()
                .HasOne(ac => ac.Cover)
                .WithMany(c => c.ArtistLinks)
                .HasForeignKey(ac => ac.CoverId);

            modelBuilder.Entity<Book>()
                .Property(b => b.BasePrice)
                .HasPrecision(10, 2);
        }
    }
}
