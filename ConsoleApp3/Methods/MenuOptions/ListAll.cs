
using System.Data.SqlClient;


namespace SQLLabb1.Methods.MenuOptions
{
    internal class ListAll
    {
        public static void ListAllStudents()
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Sort by: 1. FirstName, 2. LastName");
                    int sortOption = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Order: 1. Ascending, 2. Descending");
                    int orderOption = Convert.ToInt32(Console.ReadLine());

                    string sortColumn = sortOption == 1 ? "FirstName" : "LastName";
                    string sortOrder = orderOption == 1 ? "ASC" : "DESC";

                    string sqlQuery = $"SELECT * FROM Students ORDER BY {sortColumn} {sortOrder}";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Student: {reader["FirstName"]} {reader["LastName"]}, Age: {reader["Age"]}, ClassID: {reader["ClassID"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Press Enter to continue.");
               
            }
            Console.ReadLine();
        }

        public static void ListAllEmployees()
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Employees";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Firstname: {reader["FirstName"]}, LastName: {reader["LastName"]}, Role: {reader["Role"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Press Enter to continue...");
                
            }
            Console.ReadLine();
        }
    }
}
