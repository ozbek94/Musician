using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musician.Domain.Entity;

namespace Musician.Data.Config
{
    class BandMusicianConfig : IEntityTypeConfiguration<BandMusician>
    {
        public void Configure(EntityTypeBuilder<BandMusician> builder)
        {
            builder.HasQueryFilter(x => x.DeleteTime == null);
        }
    }
}
