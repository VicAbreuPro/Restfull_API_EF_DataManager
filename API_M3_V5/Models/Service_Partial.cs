using API_M3_V5.Data;

namespace API_M3_V5.Models
{
    public partial class Service
    {
        /// <summary>
        /// Get service by id, just to N-UNITY test purpose
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Service? GetService(int id)
        {
            using(var context = new m3_dbContext())
            {
                Service? service = new();
                service = context.Services.Find(id);
                return service;
            }
        }
    }
}
