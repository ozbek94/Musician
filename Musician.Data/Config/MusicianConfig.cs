using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Musician.Data.Config
{
    class MusicianConfig : IEntityTypeConfiguration<Musician.Domain.Entity.Musician>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Musician> builder)
        {
            builder.HasQueryFilter(x => x.DeleteTime == null);

            //builder.HasMany(x => x.BandMusicians)
            //    .WithOne(x => x.Musician)
            //    .HasForeignKey(x => x.MusicianId);
        }
    }
}
