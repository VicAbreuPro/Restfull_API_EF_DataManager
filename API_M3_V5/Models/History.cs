using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public string? Report { get; set; }
        public double? TimeConsumption { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
