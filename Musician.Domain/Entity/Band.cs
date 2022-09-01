using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Domain.Entity
{
    [Table("Band")]
    public class Band : EntityBase
    {
        public string Name { get; set; }

        public virtual IEnumerable<BandMusician> BandMusicians { get; set; }
    }
}
