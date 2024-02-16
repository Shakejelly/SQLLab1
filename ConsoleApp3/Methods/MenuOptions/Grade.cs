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

                string insertQuery = @"
                SELECT *
                FROM (
                    SELECT *, ROW_NUMBER() OVER(PARTITION BY StudentId ORDER BY DateReceived DESC) AS rn
                    FROM Grades
                ) AS subquery
                WHERE rn = 1;
            ";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"StudentID: {reader["StudentID"]} Grade: {reader["Grade"]} DateReceived: {reader["DateReceived"]} ");
                        }
                    }
                }
            }
        }
        public static void GetAverageGrades()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb1;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "SELECT AVG(CAST(Grade AS FLOAT)) AS AverageGrade FROM Grades";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                {
                    object result = sqlCommand.ExecuteScalar();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Average Grade: {result}");
                        }
                    }
                }
            }
        }
    }
}
