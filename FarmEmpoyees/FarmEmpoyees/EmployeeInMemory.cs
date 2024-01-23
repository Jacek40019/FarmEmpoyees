using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEmployees
{
    public class EmployeeInMemory : EmployeeBase
    {
        public override event SalaryAddedDelegate SalaryAdded;

        private List<float> salaryForFruits = new List<float>();

        private string name;
        private string surname;

        public override string Name
        {
            get
            {
                return $"{char.ToUpper(name[0])}{name.Substring(1, name.Length - 1).ToLower()}";
            }
            set
            {
                name = value;
            }
        }

        public override string Surname
        {
            get
            {
                return $"{char.ToUpper(surname[0])}{surname.Substring(1, surname.Length - 1).ToLower()}";
            }
            set
            {
                surname = value;
            }
        }

        public EmployeeInMemory(string name, string surname)
              : base(name, surname)
        {
        }

        public override void AddSalary(float salaryForFruit)
        {
            {
                if (salaryForFruit >= 0)
                {
                    this.salaryForFruits.Add(salaryForFruit);

                    if (SalaryAdded != null)
                    {
                        SalaryAdded(this, new EventArgs());
                    }
                }
                else
                {
                    this.salaryForFruits.Add(0);

                    if (SalaryAdded != null)
                    {
                        SalaryAdded(this, new EventArgs());
                    }
                    throw new Exception("invalid weightOfFruit value (negative value is not allowed)");
                }
            }
        }

        public override Statistics GetStatistics()
        {

            var data = new DataForCalculation();
            var statistics = new Statistics(data);

            foreach (var salaryForFruit in this.salaryForFruits)
            {
                statistics.AddSalary(salaryForFruit);
            }
            return statistics;
        }
    }
}