using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Business
    {
        public Business()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int BusinessId { get; set; }
        public int LocationId { get; set; }
        public int EntityId { get; set; }
        public string BusinessType { get; set; } = null!;
        public string BusinessName { get; set; } = null!;
        public int Nif { get; set; }
        public string? Addressline { get; set; }
        public string? Zipcode { get; set; }

        public virtual Entity Entity { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
