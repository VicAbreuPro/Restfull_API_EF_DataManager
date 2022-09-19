using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Service
    {
        public Service()
        {
            Budgets = new HashSet<Budget>();
            Histories = new HashSet<History>();
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public int ServiceId { get; set; }
        public int TypeId { get; set; }
        public int ClientId { get; set; }
        public int Status { get; set; }
        public string? Observations { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? State { get; set; }

        public virtual ServiceTypeDetail Type { get; set; } = null!;
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
