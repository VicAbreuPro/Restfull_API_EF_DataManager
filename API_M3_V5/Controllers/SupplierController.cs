using Microsoft.AspNetCore.Mvc;
using API_M3_V5.Models;
using API_M3_V5.Models_aux;
using API_M3_V5.Data;
using Newtonsoft.Json;

namespace API_M3_V5.Controllers
{
    [Route("Supplier")]
    [ApiController]
    public class SupplierController : Controller
    {
        /// <summary>
        /// Get supplier list
        /// </summary>
        /// <returns></returns>
        [HttpGet("SupplierList")]
        public ActionResult<string> GetSuppliers()
        {
            List<SupplierView> supplier_list = new();
            using (var context = new m3_dbContext())
            {
                supplier_list = context.SupplierViews.ToList();
            }

            if (supplier_list != null)
            {
                var json = JsonConvert.SerializeObject(supplier_list);
                return Ok(json);
            }
            else return NotFound();
        }

        /// <summary>
        /// Get supplier list by char input
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("SupplierByChar")]
        public ActionResult<string> GetSupplier_by_char(string? type, string? value)
        {
            using (var context = new m3_dbContext())
            {
                List<SupplierView> suvs = new();
                switch (type)
                {
                    case "Id":
                        suvs = context.SupplierViews.Where(cv => cv.SupplierId.ToString().StartsWith(value)).ToList();
                        break;
                    case "Business Name":
                        suvs = context.SupplierViews.Where(cv => cv.BusinessName.StartsWith(value)).ToList();
                        break;
                    case "Business Type":
                        suvs = context.SupplierViews.Where(cv => cv.BusinessType.StartsWith(value)).ToList();
                        break;
                    case "Nif":
                        suvs = context.SupplierViews.Where(cv => cv.Nif.ToString().StartsWith(value)).ToList();
                        break;
                    case "Adress":
                        suvs = context.SupplierViews.Where(cv => cv.Addressline.StartsWith(value)).ToList();
                        break;
                    case "City":
                        suvs = context.SupplierViews.Where(cv => cv.City.StartsWith(value)).ToList();
                        break;
                    case "Delivery Average":
                        suvs = context.SupplierViews.Where(cv => cv.DeliveryAverage.ToString().StartsWith(value)).ToList();
                        break;
                }
                if (suvs != null)
                {
                    var json = JsonConvert.SerializeObject(suvs);
                    return Ok(json);
                }
                else return NotFound();
            }
        }

        /// <summary>
        /// Inser new supplier in database
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost("NewSupplier")]
        public ActionResult<string> AddSupplier(Supplier_aux s)
        {
            try
            {
                // Verifcation of input data to prevent copies of info
                bool verification = Business.Verify_business_info(s);

                if (verification != false)
                {
                    // If Location input exists, get id from it
                    int id = Location.Verify_location_data(s.City, s.District, s.Country);
                    int Location_id = id;

                    // Verify if location data exists
                    using (var context = new m3_dbContext())
                    {
                        // Add new location if data dont exist in DB
                        if (id == 0) Location_id = Location.Add_location(s.City, s.District, s.Country);

                        var supplier = new Supplier
                        {
                            DeliveryAverage = s.DeliveryAverage,
                            Business = new Business
                            {
                                BusinessName = s.BusinessName,
                                BusinessType = s.BusinessType,
                                Nif = s.Nif,
                                Addressline = s.Addressline,
                                Zipcode = s.Zipcode,
                                EntityId = 2,
                                LocationId = Location_id,
                            }
                        };

                        context.Suppliers.Add(supplier);
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
    
        /// <summary>
        /// Update supplier info
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpSupplier")]
        public ActionResult<string> UpSupplier()
        {
            /*var aux = Supplier.UpdateSupplier(s);
            if (aux != false) return Ok("Success");
            else return Unauthorized();*/
            return Ok();
        }
    }
}
