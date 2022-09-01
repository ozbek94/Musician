using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musician.Domain.Entity;

namespace Musician.Data.Config
{
    class BandConfig : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.HasQueryFilter(x => x.DeleteTime == null);
        }
    }
}
