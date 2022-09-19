using Microsoft.AspNetCore.Mvc;
using API_M3_V5.Models;
using API_M3_V5.Models_aux;
using API_M3_V5.Data;
using Newtonsoft.Json;

namespace API_M3_V5.Controllers
{
    [Route("Client")]
    [ApiController]
    public class ClientController : Controller
    {
        /// <summary>
        /// Get list of clients and serialize to JSON object
        /// </summary>
        /// <returns></returns>
        [HttpGet("ClientList")]
        public ActionResult<string> GetClients()
        {
             List<ClientView> client_list = new();
            using(var context = new m3_dbContext())
            {
                client_list = context.ClientViews.ToList();
            }

            if (client_list != null) {
                var json = JsonConvert.SerializeObject(client_list);
                return Ok(json);
            }
            else return NotFound();
        }

        /// <summary>
        /// Get client by id and serialize to JSON object
        /// </summary>
        /// <param name="cli_id"></param>
        /// <returns></returns>
        [HttpGet("ClientById")]
        public ActionResult<string> GetClientbyID(string? cli_id)
        {
            Client_aux? client = Client_aux.GetCliById(cli_id);
            if(client != null)
            {
                var json = JsonConvert.SerializeObject(client);
                return Ok(json);
            }
            return NotFound("client not found");
        }

        /// <summary>
        /// Get client by input char
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("ClientByChar")]
        public ActionResult<string> GetServices_by_char(string type, string value)
        {
            using (var context = new m3_dbContext())
            {
                List<ClientView> cvs = new();
                switch (type)
                {
                    case "Id":
                        cvs = context.ClientViews.Where(cv => cv.ClientId.ToString().StartsWith(value)).ToList();
                        break;
                    case "Username":
                        cvs = context.ClientViews.Where(cv => cv.Username.StartsWith(value)).ToList();
                        break;
                    case "First Name":
                        cvs = context.ClientViews.Where(cv => cv.FirstName.StartsWith(value)).ToList();
                        break;
                    case "Surname":
                        cvs = context.ClientViews.Where(cv => cv.Surname.StartsWith(value)).ToList();
                        break;
                    case "Email":
                        cvs = context.ClientViews.Where(cv => cv.Email.StartsWith(value)).ToList();
                        break;
                    case "Phone":
                        cvs = context.ClientViews.Where(cv => cv.Phone.ToString().StartsWith(value)).ToList();
                        break;
                    case "Nif":
                        cvs = context.ClientViews.Where(cv => cv.Nif.ToString().StartsWith(value)).ToList();
                        break;
                    case "Zipcode":
                        cvs = context.ClientViews.Where(cv => cv.Zipcode.ToString().StartsWith(value)).ToList();
                        break;
                    case "Address":
                        cvs = context.ClientViews.Where(cv => cv.Addressline.StartsWith(value)).ToList();
                        break;
                    case "City":
                        cvs = context.ClientViews.Where(cv => cv.City.StartsWith(value)).ToList();
                        break;
                    case "State":
                        cvs = context.ClientViews.Where(cv => cv.District.StartsWith(value)).ToList();
                        break;
                    case "Country":
                        cvs = context.ClientViews.Where(cv => cv.Country.StartsWith(value)).ToList();
                        break;
                }
                if (cvs != null)
                {
                    var json = JsonConvert.SerializeObject(cvs);
                    return Ok(json);
                }
                else return NotFound();
            }
        }

        /// <summary>
        /// Insert New client in database
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost("NewClient")]
        public ActionResult<string> AddClient(Client_aux c)
        {
            try
            {
                // Verifcation of input data to prevent copies of info
                bool verification = Client.Verify_client_info(c);

                if (verification != false)
                {
                    // If Location input exists, get id from it
                    int id = Location.Verify_location_data(c.City, c.District, c.Country);
                    int Location_id = id;

                    // Verify if location data exists
                    using (var context = new m3_dbContext())
                    {
                        // Add new location if data dont exist in DB
                        if (id == 0) Location_id = Location.Add_location(c.City, c.District, c.Country);

                        var client = new Client
                        {
                            Username = c.Username,
                            Person = new Person
                            {
                                FirstName = c.FirstName,
                                Surname = c.Surname,
                                Nif = c.Nif,
                                Email = c.Email,
                                Phone = c.Phone,
                                Addressline = c.Addressline,
                                Zipcode = c.Zipcode,
                                EntityId = 1,
                                LocationId = Location_id,
                            }
                        };

                        context.Clients.Add(client);
                        context.SaveChanges();
                        return Ok("success");
                    }
                }else return BadRequest("Data input exist in Database");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        /// <summary>
        /// Upadte client with auxiliary class model
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPut("UpClient")]
        public ActionResult<string> UpClient(Client_aux c)
        {
            try
            {
                int id = Location.Verify_location_data(c.City, c.District, c.Country);
                int Location_id = id;

                using (var context = new m3_dbContext())
                {
                    int person_id = Person.Get_person_id(c.ClientId);
                    c.PersonId = person_id;

                    if (id == 0) Location_id = Location.Add_location(c.City, c.District, c.Country);

                    var client = new Client
                    {
                        ClientId = c.ClientId,
                        Username = c.Username,
                        Person = new Person
                        {
                            PersonId = c.PersonId,
                            FirstName = c.FirstName,
                            Surname = c.Surname,
                            Nif = c.Nif,
                            Email = c.Email,
                            Phone = c.Phone,
                            Addressline = c.Addressline,
                            Zipcode = c.Zipcode,
                            EntityId = 1,
                            LocationId = Location_id,
                        }
                    };
                    context.Clients.Update(client);
                    context.SaveChanges();
                    return Ok("success");
                }
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
