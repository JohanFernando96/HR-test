using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HR_test.Pages.Clients
{
    public class IndexModel : PageModel
    { 
        public List<EmployeeInfo> listEmployees = new List<EmployeeInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\MSSQLTESTSERVER;Initial Catalog=employee;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    connection.Open();
                    String sql = "SELECT * FROM employee";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        { 
                            while (reader.Read())
                            {
                                EmployeeInfo emp = new EmployeeInfo();
                                emp.id = "" + reader.GetInt32(0);
                                emp.name = reader.GetString(1);
                                emp.email = reader.GetString(2);

                                listEmployees.Add(emp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class EmployeeInfo
    {
        public string? id;
        public string? name;
        public string? email;
    }
}
