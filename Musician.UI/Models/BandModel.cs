using Musician.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musician.UI.Models
{
    public class BandModel
    {
        public string Name { get; set; }
        public virtual IEnumerable<BandMusician> BandMusicians { get; set; }
    }
}
