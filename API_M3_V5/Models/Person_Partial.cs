using API_M3_V5.Data;


namespace API_M3_V5.Models
{
    public partial class Person
    {
        public static int Get_person_id(int? client_id)
        {
            int id;
            using (var context = new m3_dbContext())
            {
                return id = context.Clients.Find(client_id).PersonId;
            }
        }

        public static int Get_employee_person_id(int? staff_id)
        {
            int id;
            using (var context = new m3_dbContext())
            {
                return id = context.Employees.Find(staff_id).PersonId;
            }
        }
    }
}
