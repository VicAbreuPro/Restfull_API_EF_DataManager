using API_M3_V5.Data;

namespace API_M3_V5.Models
{
    public partial class Location
    {
        /// <summary>
        /// Verification of Location data input, if exist on database, return id
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static int Verify_location_data(string? city, string? state, string? country)
        {
            int id = 0;
            using (var context = new m3_dbContext())
            {
                List<Location> location_list = new();
                location_list = context.Locations.ToList();
                foreach (var location in location_list)
                {
                    if (location.City == city && location.District == state && location.Country == country) id = location.LocationId;
                }
            }
            return id;
        }

        /// <summary>
        /// Add new location in database and return id
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static int Add_location(string city, string state, string country)
        {
            int new_id;
            using (var context = new m3_dbContext())
            {
                Location new_location = new();

                new_location.City = city;
                new_location.District = state;
                new_location.Country = country;

                context.Locations.Add(new_location);
                context.SaveChanges();

                new_id = Verify_location_data(city, state, country);
                return new_id;
            }
        }
    }
}
