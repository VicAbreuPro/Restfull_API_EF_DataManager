using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class ClientView
    {
        public int ClientId { get; set; }
        public int PersonId { get; set; }
        public int LocationId { get; set; }
        public int EntityId { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Email { get; set; }
        public int Phone { get; set; }
        public int? Nif { get; set; }
        public string? Addressline { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
