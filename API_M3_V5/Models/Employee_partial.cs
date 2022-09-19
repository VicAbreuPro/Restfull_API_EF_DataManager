using API_M3_V5.Models_aux;
using API_M3_V5.Data;

namespace API_M3_V5.Models
{
    public partial class Employee
    {
        /// <summary>
        /// Verifcation of unique employee/person info to prevent repetitive and incorrect data insert
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool Verify_staff_info(Staff_aux c)
        {
            bool verify = true;
            using (var context = new m3_dbContext())
            {
                verify = context.EmployeeViews.Count(ev => ev.Username.Equals(c.Username) || ev.Nif == c.Nif || ev.Phone == c.Phone || ev.Email.Equals(c.Email)) == 0;
            }
            return verify;
        }
    }
}
