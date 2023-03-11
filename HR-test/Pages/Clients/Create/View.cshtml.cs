using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HR_test.Pages.Clients.View
{
    public class ViewModel : PageModel
    {
        public EmployeeInfo employeeinfo = new EmployeeInfo();
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\MSSQLTESTSERVER;Initial Catalog=employee;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM employee WHERE empid=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                employeeinfo.id = "" + reader.GetInt32(0);
                                employeeinfo.name = reader.GetString(1);
                                employeeinfo.email = reader.GetString(2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
 
        }
    }
}
