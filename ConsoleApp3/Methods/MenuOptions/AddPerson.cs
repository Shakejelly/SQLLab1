using System.Data.SqlClient;

namespace SQLLabb1.Methods.MenuOptions
{
    internal class AddPerson
    {
        public static void AddStudents()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter the correct information.");
                Console.Write("First Name: ");
                string sFirstName = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();
                Console.Write("Last Name: ");
                string sLastName = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();
                Console.Write("Age: ");
                int sAge = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();
                Console.Write("Class ID: ");
                int sClassID = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();

                string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Students (FirstName, LastName, Age, ClassID) " +
                        "VALUES (@FirstName, @LastName, @Age, @ClassID)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", sFirstName);
                        command.Parameters.AddWithValue("@LastName", sLastName);
                        command.Parameters.AddWithValue("@Age", sAge);
                        command.Parameters.AddWithValue("@ClassID", sClassID);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Student Added. Press Enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong, student not added. Press Enter to continue...");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}. Press Enter to continue...");
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
        public static void AddEmployees()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter the correct information.");
                Console.Write("First Name: ");
                string eFirstName = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();
                Console.Write("Last Name: ");
                string eLastName = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();
                Console.Write("Role: ");
                string eRole = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Utilities.Utilities.ClearCurrentConsoleLine();

                string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Employees (FirstName, LastName, Role) " +
                        "VALUES (@FirstName, @LastName, @Role)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", eFirstName);
                        command.Parameters.AddWithValue("@LastName", eLastName);
                        command.Parameters.AddWithValue("@Role", eRole);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Employee Added. Press Enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong, employee not added. Press Enter to continue...");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}. Press Enter to continue...");
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
