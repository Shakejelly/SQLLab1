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
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "SELECT Students.FirstName, Students.LastName, Courses.CourseName, Grades.Grade " +
                                     "FROM Grades " +
                                     "JOIN Students ON Grades.StudentID = Students.StudentID " +
                                     "JOIN Courses ON Grades.CourseID = Courses.CourseID " +
                                     "WHERE Grades.DateAssigned > DATEADD(month, -1, GETDATE())";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Student: {reader["FirstName"]} {reader["LastName"]}, Course: {reader["CourseName"]}, Grade: {reader["Grade"]}");
                        }
                    }
                }
            }
        }
        public static void GetAverageGrades()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "SELECT Courses.CourseName, AVG(Grades.Grade) as AverageGrade, " +
                                     "MIN(Grades.Grade) as MinGrade, MAX(Grades.Grade) as MaxGrade " +
                                     "FROM Grades " +
                                     "JOIN Courses ON Grades.CourseID = Courses.CourseID " +
                                     "GROUP BY Courses.CourseName"; ;

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Course: {reader["CourseName"]}, Average Grade: {reader["AverageGrade"]}, Min Grade: {reader["MinGrade"]}, Max Grade: {reader["MaxGrade"]}");
                        }
                    }
                }
            }
        }
    }
}
