using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Domain.Entity
{
    [Table("BandMusician")]
    public class BandMusician : EntityBase
    {
        public int BandId { get; set; }
        public virtual Band Band { get; set; }

        public int MusicianId { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
