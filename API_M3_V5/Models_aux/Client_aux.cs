using API_M3_V5.Models;
using API_M3_V5.Data;

namespace API_M3_V5.Models_aux
{
    public class Client_aux
    {
        public int ClientId { get; set; }
        public string Username { get; set; } = null!;
        public int PersonId { get; set; }
        public int EntityId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? Nif { get; set; }
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string Addressline { get; set; } = null!;
        public int Zipcode { get; set; }
        public int LocationId { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Country { get; set; } = null!;

        // Default Constructor
        public Client_aux() { }

        /// <summary>
        /// Get client by id input (PRIMARY KEY)
        /// </summary>
        /// <param name="cli_id"></param>
        /// <returns></returns>
        public static Client_aux GetCliById(string? cli_id)
        {
            using (var context = new m3_dbContext())
            {
                Client? c = new();
                Person? p = new();
                Location? l = new();
                Client_aux? client = new();

                c = context.Clients.Find(Convert.ToInt32(cli_id));
                if (c != null)
                {
                    p = context.People.Find(c.PersonId);
                    l = context.Locations.Find(p.LocationId);

                    client.ClientId = c.ClientId;
                    client.PersonId = c.PersonId;
                    client.FirstName = p.FirstName;
                    client.Surname = p.Surname;
                    client.Username = c.Username;
                    client.Email = p.Email = null!;
                    client.Phone = p.Phone;
                    client.Nif = p.Nif;
                    client.Addressline = p.Addressline = null!;
                    client.Zipcode = p.Zipcode;
                    client.City = l.City = null!;
                    client.Country = l.Country;
                    client.District = l.District;  
                }
                return client;
            }
        }
    }
}
