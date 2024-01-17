using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FarmEmployees.EmployeeBase;

namespace FarmEmployees
{        
    public interface IEmployee
    {
        string Name { get; }

        string Surname { get; }

        void AddSalary(float salaryForFruit);

        event SalaryAddedDelegate SalaryAdded;

        Statistics GetStatistics();

        void ShowStatistics();

    }
}

