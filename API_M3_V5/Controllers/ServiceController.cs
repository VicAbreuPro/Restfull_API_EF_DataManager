using Microsoft.AspNetCore.Mvc;
using API_M3_V5.Models;
using API_M3_V5.Data;
using Newtonsoft.Json;
using API_M3_V5.Models_aux;


namespace API_M3_V5.Controllers
{
    [Route("Service")]
    [ApiController]
    public class ServiceController : Controller
    {
        /// <summary>
        /// Get service list and serialize to JSON object
        /// </summary>
        /// <returns></returns>
        [HttpGet("ServiceList")]
        public ActionResult<string> GetServices()
        {

            List<ServiceView> service_list = new();
            using (var context = new m3_dbContext())
            {
                service_list = context.ServiceViews.ToList();
            }

            if (service_list != null)
            {
                var json = JsonConvert.SerializeObject(service_list);
                return Ok(json);
            }
            else return NotFound();
        }

        /// <summary>
        /// Get service list by char input according to the selected filter
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("ServiceByChar")]
        public ActionResult<string> GetServices_by_char(string? type, string? value)
        {
            using (var context = new m3_dbContext())
            {
                List<ServiceView> svs = new();
                switch (type)
                {
                    case "Id":
                        svs = context.ServiceViews.Where(cv => cv.ServiceId.ToString().StartsWith(value)).ToList();
                        break;
                    case "Client Id":
                        svs = context.ServiceViews.Where(cv => cv.ClientId.ToString().StartsWith(value)).ToList();
                        break;
                    case "Status":
                        svs = context.ServiceViews.Where(cv => cv.Status.ToString().StartsWith(value)).ToList();
                        break;
                    case "Start Date":
                        svs = context.ServiceViews.Where(cv => cv.StartDate.ToString().StartsWith(value)).ToList();
                        break;
                    case "End Date":
                        svs = context.ServiceViews.Where(cv => cv.EndDate.ToString().StartsWith(value)).ToList();
                        break;
                    case "Type":
                        svs = context.ServiceViews.Where(cv => cv.Type.StartsWith(value)).ToList();
                        break;
                    case "observations":
                        svs = context.ServiceViews.Where(cv => cv.Observations.StartsWith(value)).ToList();
                        break;
                    case "State":
                        svs = context.ServiceViews.Where(cv => cv.State.StartsWith(value)).ToList();
                        break;
                
                }
                if (svs != null)
                {
                    var json = JsonConvert.SerializeObject(svs);
                    return Ok(json);
                }
                else return NotFound();
            }
        }

        /// <summary>
        /// Get service list by client username input, and serialize to JSON object
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("ServiceByClient")]
        public ActionResult<string> GetServices_by_client(string? username)
        {
            using (var context = new m3_dbContext())
            {
                
                List<Client> client_list = context.Clients.ToList();

                List<ServiceView> list_aux = new();
                int id_aux = 0;
                
                foreach(var client in client_list)
                {
                    if (client.Username == username) id_aux = client.ClientId;
                }

                List<ServiceView> service_list = context.ServiceViews.Where(svs => svs.ClientId == id_aux).ToList();

                if (service_list != null)
                {
                    var json = JsonConvert.SerializeObject(service_list);
                    return Ok(json);
                }
                else return Unauthorized();
            }
        }

        /// <summary>
        /// Get service list by state filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("ServiceByState")]
        public ActionResult<string> GetServices_by_state(string? filter)
        {
            using(var context = new m3_dbContext())
            {
                List<ServiceView> service_list = context.ServiceViews.Where(svs => svs.State == filter).ToList();

                if (service_list != null)
                {
                    var json = JsonConvert.SerializeObject(service_list);
                    return Ok(json);
                }
                else return Unauthorized();
            }
        }

        /// <summary>
        /// Get service history list and serilize to JSON object
        /// </summary>
        /// <param name="service_id"></param>
        /// <returns></returns>
        [HttpGet("ServiceHistory")]
        public ActionResult<string> GetServices_history(string? service_id)
        {
            using(var context = new m3_dbContext())
            {
                List<History> service_history = context.Histories.Where(svh => svh.ServiceId == Convert.ToInt32(service_id)).ToList();

                if (service_history != null)
                {
                    var json = JsonConvert.SerializeObject(service_history);
                    return Ok(json);
                }
                else return Unauthorized();
            }
        }

        /// <summary>
        /// Get service orders list
        /// </summary>
        /// <param name="service_id"></param>
        /// <returns></returns>
        [HttpGet("ServiceOrders")]
        public ActionResult<string> GetServices_orders(string? service_id)
        {
            using(var context = new m3_dbContext())
            {
                List<ServiceOrder> service_orders = context.ServiceOrders.Where(svo => svo.ServiceId == Convert.ToInt32(service_id)).ToList();

                if (service_orders != null)
                {
                    var json = JsonConvert.SerializeObject(service_orders);
                    return Ok(json);
                }
                else return Unauthorized();
            }
        }

        [HttpGet("ServiceBudget")]
        public ActionResult<string> GetServices_budget(string? service_id)
        {
            using(var context =new m3_dbContext())
            {
                List<Budget> service_budgets = context.Budgets.Where(svb => svb.ServiceId == Convert.ToInt32(service_id)).ToList();

                if (service_budgets != null)
                {
                    var json = JsonConvert.SerializeObject(service_budgets);
                    return Ok(json);
                }
                else return Unauthorized();
            }
        }

        /// <summary>
        /// Insert new service in database
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost("NewService")]
        public ActionResult<string> AddService(Service_Aux s)
        {
            int service_id = 0;
            try
            {
                using (var context = new m3_dbContext())
                {
                    var service = new Service
                    {
                        TypeId = s.TypeId,
                        ClientId = s.ClientId,
                        Status = s.Status,
                        Observations = s.Observations,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        State = s.State,
                    };
                    context.Services.Add(service);
                    context.SaveChanges();

                    var service_aux = context.Services.Where(sv => sv.ClientId == s.ClientId && sv.Observations == s.Observations && sv.Status == s.Status && sv.StartDate == s.StartDate).FirstOrDefault();
                    service_id = service_aux.ServiceId;
                    
                    return Ok(service_id);
                }
            }catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Update service
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost("UpdateService")]
        public ActionResult<string> UpService(Service_Aux s)
        {
            try
            {
                using (var context = new m3_dbContext())
                {
                    var service = new Service
                    {
                        TypeId = s.TypeId,
                        ClientId = s.ClientId,
                        Status = s.Status,
                        Observations = s.Observations,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        State = s.State,
                    };
                    context.Services.Update(service);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Update service state, and add in service history the effective changes with employee id register
        /// </summary>
        /// <param name="service_id"></param>
        /// <param name="employee_id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("UpdateServiceState")]
        public ActionResult<string> UpdateServiceState(string? service_id, string? employee_id, string? state)
        {
            try
            {
                using (var context = new m3_dbContext())
                {
                    var service = context.Services.Find(Convert.ToInt32(service_id));
                    service.State = state;
                    context.Services.Update(service);
                    context.SaveChanges();

                    var service_history = new History
                    {
                        ServiceId = service.ServiceId,
                        EmployeeId = Convert.ToInt32(employee_id),
                        Report = "Service State Update to " + state,
                        TimeConsumption = 1
                    };

                    context.Histories.Add(service_history);
                    context.SaveChanges();
                    return Ok("success");
                }
            }catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

    }
}
