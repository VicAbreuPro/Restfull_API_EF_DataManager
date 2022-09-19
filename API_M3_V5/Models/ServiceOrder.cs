using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class ServiceOrder
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ServiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderQty { get; set; }
        public double OrderAmount { get; set; }
        public int OrderStatus { get; set; }
        public DateTime? ReceptionDate { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
