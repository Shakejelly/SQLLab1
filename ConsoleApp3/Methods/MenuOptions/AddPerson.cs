using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SQLLabb1.Utilities;
using System.Windows.Markup;

namespace SQLLabb1.Methods.MenuOptions
{
    internal class AddPerson
    {
        public static void AddStudents()
        {
            Console.Clear();
            Console.WriteLine("Please write in the correct information.");
            Console.Write("First Name: ");
            // s stand for student
            string sFirstName = Console.ReadLine();
            //I want to keep it a bit fance with erasing the lastest row.
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();
            Console.Write("Last Name: ");
            string sLastName = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();
            Console.Write("Age: ");
            int sAge = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();
            Console.Write("CourseID: ");
            int sCourseID = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();


            string conntectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conntectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Students (FirstName, LastName, Age, CourseID)" +
                    "VALUES (@FirstName, @LastName, @Age, @CourseID)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", sFirstName);
                    command.Parameters.AddWithValue("@LastName", sLastName);
                    command.Parameters.AddWithValue("@Age", sAge);
                    command.Parameters.AddWithValue("@CourseID", sCourseID);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Student Added");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong, student not added.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            Console.ReadLine();
        }
        public static void AddEmployees()
        {
            Console.Clear();
            Console.WriteLine("Please write in the correct information.");
            Console.Write("First Name: ");
            string eFirstName = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();
            Console.Write("Last Name: ");
            string eLastName = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();
            Console.Write("Role: ");
            string eRole = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utlities.ClearCurrentConsoleLine();
         

            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Employees (FirstName, LastName, Role)" +
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
                            Console.WriteLine("Employee Added");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong, employee not added.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                }
            }
            Console.ReadLine();
        }

    }
}
