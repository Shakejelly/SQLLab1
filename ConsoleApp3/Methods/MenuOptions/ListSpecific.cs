﻿using System.Data.SqlClient;
namespace SQLLabb1.Methods.MenuOptions
{
    internal class ListSpecific
    {
            public static void ListSpecificStudent()
            {
                try
                {
                    string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Enter the class ID:");
                        int classId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Sort by: 1. FirstName, 2. LastName");
                        int sortOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Order: 1. Ascending, 2. Descending");
                        int orderOption = Convert.ToInt32(Console.ReadLine());

                        string sortColumn = sortOption == 1 ? "FirstName" : "LastName";
                        string sortOrder = orderOption == 1 ? "ASC" : "DESC";

                        string sqlQuery = $"SELECT * FROM Students WHERE ClassID = @ClassID ORDER BY {sortColumn} {sortOrder}";

                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@ClassID", classId);

                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Student: {reader["FirstName"]} {reader["LastName"]}, Age: {reader["Age"]}");
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

            public static void ListSpecificEmployee()
            {
                try
                {
                    string connectionString = @"Data Source=(localdb)\.;Initial Catalog=SchoolLabb;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Enter the role:");
                        string role = Console.ReadLine();
                        string sqlQuery = "SELECT * FROM Employees WHERE Role = @Role";

                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@Role", role);

                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Employee: {reader["FirstName"]} {reader["LastName"]}, Role: {reader["Role"]}");
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
