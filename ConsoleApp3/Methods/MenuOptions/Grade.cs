using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLabb1.Methods.MenuOptions
{
    internal class Grade
    {
        public static void GetLatestGrades()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DateTime months = DateTime.Now.AddMonths(-1);
                string query = $"SELECT Students.FirstName + Students.LastName AS StudentName, Courses.Course, Grades.Grade " +
                               $"FROM Grades " +
                               $"INNER JOIN Students ON Grades.StudentId = Students.StudentId " +
                               $"INNER JOIN Courses ON Grades.CourseId = Courses.CourseId " +
                               $"WHERE Grades.GradeDate >= @LastMonth";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastMonth", months);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine($"Grades of the student from the past month.");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["StudentName"]}, {reader["Course"]}, {reader["Grade"]}");
                        }
                    }
                }
            }
        }
        public static void GetAverageGrades()
        {
            Console.Clear();
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "SELECT " +
                               "Courses.CourseId, " +
                               "Courses.Course, " +
                               "AVG(CAST(Grades.Grade AS FLOAT)) AS AverageGrade, " +
                               "FROM Courses " +
                               "LEFT JOIN Grades ON Courses.CourseId = Grades.CourseId ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("CourseID | Course | AverageGrade");
                        while (reader.Read())
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{reader["CourseId"]}, {reader["Course"]}, {reader["AverageGrade"]}");
                        }
                    }
                }
            }
        }
    }
}

