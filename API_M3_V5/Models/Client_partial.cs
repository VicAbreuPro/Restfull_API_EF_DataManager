using API_M3_V5.Models_aux;
using API_M3_V5.Data;

namespace API_M3_V5.Models
{
    public partial class Client
    {
        /// <summary>
        /// Verifcation of unique client/person info to prevent repetitive and incorrect data insert
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Verify_client_info(Client_aux c)
        {
            bool verify = true;
            using (var context = new m3_dbContext())
            {

                verify = context.ClientViews.Count(cv => cv.Nif == c.Nif || cv.Username.Equals(c.Username) || cv.Phone == c.Phone || cv.Email.Equals(c.Email)) == 0;
            }
            return verify;
        }
    }
}
