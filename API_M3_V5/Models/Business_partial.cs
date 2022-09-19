using API_M3_V5.Models_aux;
using API_M3_V5.Data;

namespace API_M3_V5.Models
{
    public partial class Business
    {
        /// <summary>
        /// Verifcation of unique bussines info to prevent repetitive and incorrect data insert
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Verify_business_info(Supplier_aux s)
        {
            bool verify = true;
            using (var context = new m3_dbContext())
            {
                verify = context.SupplierViews.Count(sv => sv.BusinessName.Equals(s.BusinessName) || sv.Nif == s.Nif) == 0;
            }
            return verify;
        }
    }
}
