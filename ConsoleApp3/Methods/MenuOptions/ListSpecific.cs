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
                Console.Clear();
                Console.WriteLine("This is a list of all the courses");
                string courseQuery = "SELECT * FROM Courses";
                using (SqlCommand courseCommand = new SqlCommand(courseQuery, connection))
                {
                    using (SqlDataReader reader = courseCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["CourseId"]}:{reader["Course"]}");
                        }
                    }
                }
                Console.WriteLine("Which course do you want to see the students?");
                string courseId = Console.ReadLine();

                string insertQuery = "SELECT FirstName, LastName, Courses.Course FROM Students " +
                                      "JOIN Courses ON Courses.CourseId = Students.CourseId " +
                                      "WHERE Courses.CourseId = @CourseId"; 

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@CourseId", courseId);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
                        }
                    }
                }
            }
        }
        public static void ListSpecificEmployee()
        {

            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.Clear();
                Console.WriteLine("This is a list of all the roles");
                string courseQuery = "SELECT * FROM Employees";
                using (SqlCommand courseCommand = new SqlCommand(courseQuery, connection))
                {

                    using (SqlDataReader reader = courseCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Role"]}");
                        }
                    }
                }
                Console.WriteLine("Which role do you want to get all the names from??");
                string roleInput = Console.ReadLine();

                string insertQuery = "SELECT * FROM Employees WHERE Role = @Role";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Role", roleInput);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"{reader["EmployeeId"]}: {reader["FirstName"]} {reader["LastName"]}, {reader["Role"]}");
                        }
                    }
                }
            }
        }
    }
}
