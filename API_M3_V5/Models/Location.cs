using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Location
    {
        public Location()
        {
            Businesses = new HashSet<Business>();
            People = new HashSet<Person>();
        }

        public int LocationId { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
