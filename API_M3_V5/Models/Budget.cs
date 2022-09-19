using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Budget
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public double Cost { get; set; }
        public string BudgetReport { get; set; } = null!;

        public virtual Service Service { get; set; } = null!;
    }
}
