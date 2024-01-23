using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEmployees
{
    public class Statistics
    {
        public float Count { get; private set; }
        public float Sum { get; private set; }
        public float DailyWorkingNorm { get; private set; }
        public float WeeklyWorkingNorm { get; private set; }
        public float StandardHourlyIncome { get; private set; }

        public float HourlyAverage
        {
            get
            {
                return this.Sum / WeeklyWorkingNorm;
            }
        }

        public float DaylyAverage
        {
            get
            {
                return HourlyAverage * DailyWorkingNorm;
            }
        }

        public float DeviationFromStandardHourlyIncome
        {
            get
            {
                return ((HourlyAverage / StandardHourlyIncome) - 1) * 100;
            }
        }

        public Statistics(DataForCalculation data)
        {
            this.Count = 0;
            this.Sum = 0;

            this.DailyWorkingNorm = data.DailyWorkingNorm;
            this.WeeklyWorkingNorm = data.WeeklyWorkingNorm;
            this.StandardHourlyIncome = data.StandardHourlyIncome;
        }

        public void AddSalary(float salary)
        {
            this.Count++;
            this.Sum += salary;
        }
    }
}
