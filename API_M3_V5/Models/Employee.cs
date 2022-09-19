using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Histories = new HashSet<History>();
        }

        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; } = null!;
        public string? JobTitle { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<History> Histories { get; set; }
    }
}
