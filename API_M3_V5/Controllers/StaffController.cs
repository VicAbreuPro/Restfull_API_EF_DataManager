using Microsoft.AspNetCore.Mvc;
using API_M3_V5.Models;
using API_M3_V5.Models_aux;
using API_M3_V5.Data;
using Newtonsoft.Json;

namespace API_M3_V5.Controllers
{
    [Route("Staff")]
    [ApiController]
    public class StaffController : Controller
    {
        /// <summary>
        /// Get staff list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("EmployeeList")]
        public ActionResult<string> GetEmployees()
        {
            List<EmployeeView> staff_list = new();
            try
            {
                using (var context = new m3_dbContext())
                {
                    staff_list = context.EmployeeViews.ToList();
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            if (staff_list != null)
            {
                var json = JsonConvert.SerializeObject(staff_list);
                return Ok(json);
            }
            else return NotFound();
        }

        /// <summary>
        /// Get staff list by char input
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("StaffByChar")]
        public ActionResult<string> GetStaffs_by_char(string? type, string? value)
        {
            using (var context = new m3_dbContext())
            {
                List<EmployeeView> evs = new();
                switch (type)
                {
                    case "Id":
                        evs = context.EmployeeViews.Where(cv => cv.EmployeeId.ToString().StartsWith(value)).ToList();
                        break;
                    case "Username":
                        evs = context.EmployeeViews.Where(cv => cv.Username.StartsWith(value)).ToList();
                        break;
                    case "Job Tittle":
                        evs = context.EmployeeViews.Where(cv => cv.JobTitle.StartsWith(value)).ToList();
                        break;
                    case "First Name":
                        evs = context.EmployeeViews.Where(cv => cv.FirstName.StartsWith(value)).ToList();
                        break;
                    case "Surname":
                        evs = context.EmployeeViews.Where(cv => cv.Surname.StartsWith(value)).ToList();
                        break;
                    case "Email":
                        evs = context.EmployeeViews.Where(cv => cv.Email.StartsWith(value)).ToList();
                        break;
                    case "Phone":
                        evs = context.EmployeeViews.Where(cv => cv.Phone.ToString().StartsWith(value)).ToList();
                        break;
                    case "Nif":
                        evs = context.EmployeeViews.Where(cv => cv.Nif.ToString().StartsWith(value)).ToList();
                        break;
                    case "Zipcode":
                        evs = context.EmployeeViews.Where(cv => cv.Zipcode.ToString().StartsWith(value)).ToList();
                        break;
                    case "Address":
                        evs = context.EmployeeViews.Where(cv => cv.Addressline.StartsWith(value)).ToList();
                        break;
                    case "City":
                        evs = context.EmployeeViews.Where(cv => cv.City.StartsWith(value)).ToList();
                        break;
                    case "State":
                        evs = context.EmployeeViews.Where(cv => cv.District.StartsWith(value)).ToList();
                        break;
                    case "Country":
                        evs = context.EmployeeViews.Where(cv => cv.Country.StartsWith(value)).ToList();
                        break;
                }
                if (evs != null)
                {
                    var json = JsonConvert.SerializeObject(evs);
                    return Ok(json);
                }
                else return NotFound();
            }
        }

        /// <summary>
        /// Register new employee in database
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost("NewStaff")]
        public ActionResult<string> AddEmployee(Staff_aux e)
        {
            try
            {
                int emp_id;

                // Verifcation of input data to prevent copies of info
                bool verification = Employee.Verify_staff_info(e);

                if (verification != false)
                {
                    // If Location input exists, get id from it
                    int id = Location.Verify_location_data(e.City, e.District, e.Country);
                    int Location_id = id;

                    using (var context = new m3_dbContext())
                    {
                        // Add new location if data dont exist in DB
                        if (id == 0) Location_id = Location.Add_location(e.City, e.District, e.Country);

                        var employee = new Employee
                        {
                            Username = e.Username,
                            JobTitle = e.JobTitle,
                            Person = new Person
                            {
                                FirstName = e.FirstName,
                                Surname = e.Surname,
                                Nif = e.Nif,
                                Phone = e.Phone,
                                Addressline = e.Addressline,
                                Email = e.Email,
                                Zipcode = e.Zipcode,
                                EntityId = 3,
                                LocationId = Location_id,
                            }
                        };
                        context.Employees.Add(employee);
                        context.SaveChanges();

                        var emp_aux = context.Employees.Where(emp => emp.Person.FirstName == employee.Person.FirstName && emp.Person.Email == employee.Person.Email).FirstOrDefault();
                        emp_id = emp_aux.EmployeeId;


                        return Ok(emp_id.ToString());
                    }
                }else return BadRequest("Data input exist in Database");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Update staff
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPut("UpStaff")]
        public ActionResult<string> UpEmployee(Staff_aux e)
        {
            try
            {
                // Verifcation of input data to prevent copies of info
                bool verification = Employee.Verify_staff_info(e);

                if (verification != false)
                {
                    // If Location input exists, get id from it
                    int id = Location.Verify_location_data(e.City, e.District, e.Country);
                    int Location_id = id;

                    using (var context = new m3_dbContext())
                    {
                    int person_id = Person.Get_employee_person_id(e.EmployeeId);
                        // Add new location if data dont exist in DB
                        if (id == 0) Location_id = Location.Add_location(e.City, e.District, e.Country);

                        var employee = new Employee
                        {
                            EmployeeId = e.EmployeeId,
                            Username = e.Username,
                            JobTitle = e.JobTitle,
                            Person = new Person
                            {
                                FirstName = e.FirstName,
                                Surname = e.Surname,
                                Nif = e.Nif,
                                Phone = e.Phone,
                                Addressline = e.Addressline,
                                Email = e.Email,
                                Zipcode = e.Zipcode,
                                EntityId = 3,
                                LocationId = Location_id,
                            }
                        };
                        context.Employees.Update(employee);
                        context.SaveChanges();

                        return Ok("success");
                    }
                }
                else return BadRequest("Data input exist in Database");
            }
            catch (Exception ex)
        {
                return Unauthorized(ex.Message);
            }
        }
    }
}
