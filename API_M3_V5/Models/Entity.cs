using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Entity
    {
        public Entity()
        {
            Businesses = new HashSet<Business>();
            People = new HashSet<Person>();
        }

        public int EntityId { get; set; }
        public string EntityType { get; set; } = null!;

        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
