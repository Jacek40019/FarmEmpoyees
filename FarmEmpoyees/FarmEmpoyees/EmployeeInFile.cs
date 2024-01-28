using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FarmEmployees
{
    public class EmployeeInFile : EmployeeBase
    {
        public override event SalaryAddedDelegate SalaryAdded;

        private const string suffixFilename = "_FARMemployee.txt";

        private string filename;

       
        public EmployeeInFile(string name, string surname)
               : base(name, surname)
        {
            filename = $"{Name}_{Surname}{suffixFilename}";
        }

        public override void AddSalary(float salaryForFruit)
        {
            using (var writer = File.AppendText(filename))
            {

                if (salaryForFruit >= 0)
                {
                    writer.WriteLine(salaryForFruit);

                    if (SalaryAdded != null)
                    {
                        SalaryAdded(this, new EventArgs());
                    }
                }
                else
                {
                    writer.WriteLine(0);

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

            if (File.Exists($"{filename}"))
            {
                using (var reader = new StreamReader($"{filename}"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var value = float.Parse(line);
                        statistics.AddSalary(value);
                    }
                }
            }
            return statistics;
        }
    }
}
