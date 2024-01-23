using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEmployees
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void SalaryAddedDelegate (object sender, EventArgs args);
        
        public abstract event SalaryAddedDelegate SalaryAdded;

        public EmployeeBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract void AddSalary(float salaryForFruit);
        public abstract Statistics GetStatistics();
        
        
        public void ShowStatistics()
        {
            var employeeStat = GetStatistics();
            if (employeeStat.Count != 0)
            {
                Console.WriteLine("\n-------------------------------------------------------------------------------------------- ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"                    Employee {Name} {Surname} - salary statistics: ");
                Console.ResetColor();
                Console.WriteLine("-------------------------------------------------------------------------------------------- ");
                Console.WriteLine($"Total salary: {(float)Math.Round(employeeStat.Sum, 2, MidpointRounding.AwayFromZero)} PLN");
                Console.WriteLine($"Salary per day: {(float)Math.Round(employeeStat.DaylyAverage, 2, MidpointRounding.AwayFromZero)} PLN");
                Console.WriteLine($"Salary per hour: {(float)Math.Round(employeeStat.HourlyAverage, 2, MidpointRounding.AwayFromZero)} PLN");

                if (employeeStat.HourlyAverage > employeeStat.StandardHourlyIncome)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Deviation from the hourly incom norm: + {(float)Math.Round(employeeStat.DeviationFromStandardHourlyIncome, 2, MidpointRounding.AwayFromZero)} %");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Hourly incom norm: {(float)Math.Round(employeeStat.StandardHourlyIncome, 2, MidpointRounding.AwayFromZero)} PLN");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Deviation from the hourly incom norm: {(float)Math.Round(employeeStat.DeviationFromStandardHourlyIncome, 2, MidpointRounding.AwayFromZero)} %");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Hourly incom norm: {(float)Math.Round(employeeStat.StandardHourlyIncome, 2, MidpointRounding.AwayFromZero)} PLN");
                    Console.ResetColor();
                }
            }
        }
    }
}
