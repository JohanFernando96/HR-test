using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace HR_test.Pages.Clients.Create
{
    public class CreateModel : PageModel
    {
        public EmployeeInfo employeeInfo = new EmployeeInfo();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            employeeInfo.name = Request.Form["name"];
            employeeInfo.email = Request.Form["email"];
            
            //Saving Data

            try
            {
                String connectionString = "Data Source=.\\MSSQLTESTSERVER;Initial Catalog=employee;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO employee " +
                                 "(empName, empEmail) VALUES " +
                                 "(@name, @email);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", employeeInfo.name);
                        command.Parameters.AddWithValue("@email", employeeInfo.email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return;
            }
        }
    }
}
