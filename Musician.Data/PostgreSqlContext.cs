using Microsoft.EntityFrameworkCore;
using Musician.Data.Config;
using Musician.Domain.Entity;

namespace Musician.Data
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Entity.Musician> Musicians { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandMusician> BandMusicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new MusicianConfig())
                .ApplyConfiguration(new BandConfig())
                .ApplyConfiguration(new BandMusicianConfig());
        }
    }
}
