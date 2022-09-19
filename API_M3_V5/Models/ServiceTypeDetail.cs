using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class ServiceTypeDetail
    {
        public ServiceTypeDetail()
        {
            Services = new HashSet<Service>();
        }

        public int TypeId { get; set; }
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
    }
}
