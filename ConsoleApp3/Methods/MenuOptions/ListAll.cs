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
            Console.WriteLine("Sort by: 1. First Name 2. Last Name");
            int sortOption = Convert.ToInt32(Console.ReadLine());
            string sortColumn = sortOption == 1 ? "FirstName" : "LastName";
            Console.WriteLine("Order: 1. Ascending 2. Descending");
            int orderOption = Convert.ToInt32(Console.ReadLine());
            string order = orderOption == 1 ? "ASC" : "DESC";

            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM Students ORDER BY {sortColumn} {order}";


                using (SqlCommand commands = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = commands.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Student: {reader["FirstName"]} {reader[\"LastName"]}, Age: {reader["Age"]}, ClassID: {reader["ClassID"]}");
                        }
                    }
                }
            }
        }
        public static void ListAllEmployees()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM Employees";

                using (SqlCommand commands = new SqlCommand(sqlQuery, connection))
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
