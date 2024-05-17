using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLabb1.Methods.MenuOptions
{
    internal class ListSpecific
    {
        public static void ListSpecificStudent()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = " ";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("");
                        }
                    }
                }
            }
        }
        public static void ListSpecificEmployee()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter the role:");
                string role = Console.ReadLine();

                string insertQuery = "SELECT * FROM employees" +
                    "WHERE Role = @Role";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery))
                {
                    sqlCommand.Parameters.AddWithValue("@Role", role);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"Employee: {reader["FirstName"]} {reader["LastName"]}, Role: {reader["Role"]}");
                        }
                    }
                }
            }
        }
    }
}
