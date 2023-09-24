using Microsoft.EntityFrameworkCore;
using URLShortening.DAL.Entity;
using URLShortening.DAL.Parameters;

namespace URLShortening.DAL
{
    public class URLContext : DbContext
    {
        public URLContext() { }
        public URLContext(DbContextOptions options) : base(options) { }

        public DbSet<ShortenedUrl> ShortenedUrl { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO: API yolunuı alıyor. DAL'a çevrilmesi lazım
                var directory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                optionsBuilder.UseSqlite($"Data Source={directory}\\URLShortening.DAL\\ShortenedDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShortenedUrl>(builder =>
            {
                builder.HasIndex(x => x.ShortUrl).IsUnique();
                builder.Property(x => x.Code).HasMaxLength(ConstantParameters.MaxCharHashLength);
            });
        }
    }
}
