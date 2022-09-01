using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Domain.Entity
{
    [Table("Musician")]
    public class Musician : EntityBase
    {
        public string Name { get; set; }

        //public virtual IEnumerable<Instrument> Instruments { get; set; }

        public virtual IEnumerable<BandMusician> BandMusicians { get; set; }
    }
}