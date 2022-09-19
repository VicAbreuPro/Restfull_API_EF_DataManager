using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class ServiceView
    {
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Observations { get; set; }
        public string? State { get; set; }
    }
}
