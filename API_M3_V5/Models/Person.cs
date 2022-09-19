using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Person
    {
        public Person()
        {
            Administrators = new HashSet<Administrator>();
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
        }

        public int PersonId { get; set; }
        public int EntityId { get; set; }
        public int LocationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? Nif { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        public string? Addressline { get; set; }
        public int Zipcode { get; set; }

        public virtual Entity Entity { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
