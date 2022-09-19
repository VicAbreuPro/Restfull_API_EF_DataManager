using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class SupplierView
    {
        public int SupplierId { get; set; }
        public int BusinessId { get; set; }
        public int LocationId { get; set; }
        public int EntityId { get; set; }
        public string BusinessName { get; set; } = null!;
        public string BusinessType { get; set; } = null!;
        public int Nif { get; set; }
        public string? Addressline { get; set; }
        public string? Zipcode { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Country { get; set; } = null!;
        public double? DeliveryAverage { get; set; }
    }
}
