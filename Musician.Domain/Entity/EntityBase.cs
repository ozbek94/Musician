using System;

namespace Musician.Domain.Entity
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
