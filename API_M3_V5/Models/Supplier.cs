using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Items = new HashSet<Item>();
        }

        public int SupplierId { get; set; }
        public int BusinessId { get; set; }
        public double? DeliveryAverage { get; set; }

        public virtual Business Business { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; }
    }
}
