using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLabb1.Methods;
using SQLLabb1.Methods.MenuOptions;

namespace SQLLabb1.Utilities
{
    internal class UI
    {
        public static void Menu()
        {

            Console.WriteLine("1. Students. ");
            Console.WriteLine("2. Employees. ");
            Console.WriteLine("3. Grades. ");
            Console.WriteLine("4. Add. ");

            int menuOption = Convert.ToInt32(Console.ReadLine());
            switch (menuOption)
            {
                case 1:
                    Students();
                    break;
                case 2:
                    Employees();
                    break;
                case 3:
                    Grades();
                    break;
                case 4:
                    Add();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
        public static void Students()
        {
            Console.Clear();
            Console.WriteLine("1. List of all students. ");
            Console.WriteLine("2. Get all student from certain class.");
            Console.WriteLine("3. Exit ");

            int studentOption = Convert.ToInt32(Console.ReadLine());
            switch (studentOption)
            {
                case 1:
                    ListAll.ListAllStudents();
                    break;
                case 2:
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }
        public static void Employees()
        {
            Console.Clear();
            Console.WriteLine("1. List all employees ");
            Console.WriteLine("2. List all employees in certain role. ");
            Console.WriteLine("3. Exit ");

            int employeesOption = Convert.ToInt32(Console.ReadLine());
            switch (employeesOption)
            {
                case 1:
                    ListAll.ListAllEmployees();
                    break;
                case 2:
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public static void Grades()
        {
            Console.Clear();
            Console.WriteLine("1. Get all grades from latest month. ");
            Console.WriteLine("2. Average grades.");
            Console.WriteLine("3. Exit ");

            int gradesOption = Convert.ToInt32(Console.ReadLine());
            switch (gradesOption)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public static void Add()
        {
            Console.Clear();
            Console.WriteLine("1. Add employee. ");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Exit ");

            int addOption = Convert.ToInt32(Console.ReadLine());
            switch (addOption)
            {
                case 1:
                    AddPerson.AddEmployees();
                    break;
                case 2:
                    AddPerson.AddStudents();
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
