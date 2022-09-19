namespace API_M3_V5.Models_aux
{
    public class Staff_aux
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int PersonId { get; set; }
        public int EntityId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Nif { get; set; }
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string Addressline { get; set; } = null!;
        public int Zipcode { get; set; }
        public int LocationId { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Country { get; set; } = null!;

        public Staff_aux() { }
    }
}
