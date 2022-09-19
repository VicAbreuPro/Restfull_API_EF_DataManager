using API_M3_V5.Data;

namespace API_M3_V5.Models_aux
{
    public class Service_Aux
    {
        public int ServiceId { get; set; }
        public int TypeId { get; set; }
        public int ClientId { get; set; }
        public int Status { get; set; }
        public string Observations { get; set; } = null!;
        public string State { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Method to return id ** JUST TO N-UNITY TEST PURPOSE **
        /// </summary>
        /// <param name="client_id"></param>
        /// <param name="start_date"></param>
        /// <param name="observation"></param>
        /// <returns></returns>
        public static string? Get_Service_Id_Aux(int client_id, DateTime start_date, string? observation)
        {
            try
            {
                using(var context = new m3_dbContext())
                {
                    var service_aux = context.Services.Where(sv => sv.ClientId == client_id && sv.Observations == observation && sv.StartDate == start_date).FirstOrDefault();
                    return service_aux.ServiceId.ToString();
                }
            }catch
            {
                return null;
            }
        }
    }
}
