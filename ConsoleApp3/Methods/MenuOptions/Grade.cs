
using System.Data.SqlClient;


namespace SQLLabb1.Methods.MenuOptions
{
    internal class Grade
    {
        public static void GetLatestGrades()
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT Students.FirstName, Students.LastName, Courses.CourseName, Grades.Grade " +
                                      "FROM Grades " +
                                      "JOIN Students ON Grades.StudentID = Students.StudentID " +
                                      "JOIN Courses ON Grades.CourseID = Courses.CourseID " +
                                      "WHERE Grades.DateAssigned > DATEADD(month, -1, GETDATE())";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Press Enter to continue...");
                
            }
            Console.ReadLine();
        }
        public static void GetAverageGrades()
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT Courses.CourseName, AVG(Grades.Grade) as AverageGrade, " +
                                      "MIN(Grades.Grade) as MinGrade, MAX(Grades.Grade) as MaxGrade " +
                                      "FROM Grades " +
                                      "JOIN Courses ON Grades.CourseID = Courses.CourseID " +
                                      "GROUP BY Courses.CourseName";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Press Enter to continue...");
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        //      /////This is a little thing I tried doing but it didn't work. But it's not in the demands
        //        public static void AssignGrade()
        //        {
        //            try
        //            {
        //                Console.Clear();
        //                Console.WriteLine("Enter the Student ID:");
        //                int studentId = Convert.ToInt32(Console.ReadLine());

        //                Console.WriteLine("Enter the Course ID:");
        //                int courseId = Convert.ToInt32(Console.ReadLine());

        //                Console.WriteLine("Enter the Grade (1-5):");
        //                int grade = Convert.ToInt32(Console.ReadLine());

        //                if (grade < 1 || grade > 5)
        //                {
        //                    Console.WriteLine("Invalid grade. Please enter a grade between 1 and 5. Press Enter to continue...");
        //                    Console.ReadLine();
        //                    return;
        //                }

        //                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolLabb1;Integrated Security=True";
        //                using (SqlConnection connection = new SqlConnection(connectionString))
        //                {
        //                    connection.Open();

        //                    // Check if the StudentID exists
        //                    string checkStudentIdQuery = "SELECT COUNT(*) FROM Students WHERE StudentID = @StudentID";
        //                    using (SqlCommand checkCommand = new SqlCommand(checkStudentIdQuery, connection))
        //                    {
        //                        checkCommand.Parameters.AddWithValue("@StudentID", studentId);
        //                        int studentExists = (int)checkCommand.ExecuteScalar();

        //                        if (studentExists == 0)
        //                        {
        //                            Console.WriteLine("The specified Student ID does not exist. Press Enter to continue...");
        //                            Console.ReadLine();
        //                            return;
        //                        }
        //                    }

        //                    // Check if the CourseID exists
        //                    string checkCourseIdQuery = "SELECT COUNT(*) FROM Courses WHERE CourseID = @CourseID";
        //                    using (SqlCommand checkCommand = new SqlCommand(checkCourseIdQuery, connection))
        //                    {
        //                        checkCommand.Parameters.AddWithValue("@CourseID", courseId);
        //                        int courseExists = (int)checkCommand.ExecuteScalar();

        //                        if (courseExists == 0)
        //                        {
        //                            Console.WriteLine("The specified Course ID does not exist. Press Enter to continue...");
        //                            Console.ReadLine();
        //                            return;
        //                        }
        //                    }

        //                    // Assign the grade
        //                    string insertGradeQuery = "INSERT INTO Grades (StudentID, CourseID, Grade, DateAssigned) " +
        //                                              "VALUES (@StudentID, @CourseID, @Grade, GETDATE())";

        //                    using (SqlCommand insertGradeCommand = new SqlCommand(insertGradeQuery, connection))
        //                    {
        //                        insertGradeCommand.Parameters.AddWithValue("@StudentID", studentId);
        //                        insertGradeCommand.Parameters.AddWithValue("@CourseID", courseId);
        //                        insertGradeCommand.Parameters.AddWithValue("@Grade", grade);

        //                        int rowsAffected = insertGradeCommand.ExecuteNonQuery();
        //                        if (rowsAffected > 0)
        //                        {
        //                            Console.WriteLine("Grade assigned successfully. Press Enter to continue...");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Failed to assign grade. Press Enter to continue...");
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Error: {ex.Message}. Press Enter to continue...");
        //            }
        //            Console.ReadLine();
               }
    }

