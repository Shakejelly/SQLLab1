﻿using System;
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

                string insertQuery = " ";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(" ");
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

                string insertQuery = " ";

                using (SqlCommand sqlCommand = new SqlCommand(insertQuery))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(" ");
                        }
                    }
                }
            }
        }
    }
}
