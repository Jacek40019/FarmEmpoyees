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