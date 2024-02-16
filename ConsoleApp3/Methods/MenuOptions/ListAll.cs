using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLabb1.Methods.MenuOptions
{
    internal class ListAll
    {
        public static void ListAllStudents()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "SELECT * FROM Students";

                using (SqlCommand commands = new SqlCommand(insertQuery, connection))
                {
                    using (SqlDataReader reader = commands.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"First Name: {reader["FirstName"]} LastName: {reader["LastName"]} Age: {reader["Age"]}");
                        }
                    }
                }
            }
        }
        public static void ListAllEmployees()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "SELECT * FROM Employees";

                using (SqlCommand commands = new SqlCommand(insertQuery, connection))
                {
                    using (SqlDataReader reader = commands.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Firstname: {reader["FirstName"]} LastName: {reader["LastName"]} Role: {reader["Role"]} ");
                        }
                    }
                }
            }
        }
    }
}
