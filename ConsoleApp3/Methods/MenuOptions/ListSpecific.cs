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
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "SELECT FirstName, LastName, Courses.Course FROM Students " +
                                      "JOIN Courses ON Course.CourseId = Students.CourseId " +
                                      "WHERE Courses.CourseId = @CourseID"; 

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["FirstName"]}, {reader["LastName"]}, {reader["Role"]}");
                        }
                    }
                }
            }
        }
        static void ListSpecificEmployee()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "SELECT * FROM Employees WHERE Role = @Role";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    //sqlCommand.Parameters.AddWithValue("@Role", selectedRole);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"{reader["EmployeeId"]}. {reader["LastName"]}, {reader["Role"]}");
                        }
                    }
                }
            }
        }
    }
}
