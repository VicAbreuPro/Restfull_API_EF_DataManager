using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Item
    {
        public Item()
        {
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public int ItemId { get; set; }
        public int SupplierId { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string ItemRef { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string PartNumber { get; set; } = null!;
        public int ItemQty { get; set; }
        public double UnitPrice { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
