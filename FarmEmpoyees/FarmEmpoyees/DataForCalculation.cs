using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEmployees
{
    public class DataForCalculation
    {

        public string[] Fruits { get; } = { "Apple", "Strawberries", "Grapes", "Berries" };
        public float RateKgApple { get; private set; }
        public float RateKgStrawberries { get; private set; }
        public float RateKgGrapes { get; private set; }
        public float RateKgBerries { get; private set; }
        public float DailyWorkingNorm { get; private set; }
        public float WeeklyWorkingNorm { get; private set; }
        public float StandardHourlyIncome { get; private set; }

        public DataForCalculation()
        {
            this.RateKgApple = 0.20f;
            this.RateKgStrawberries = 1.20f;
            this.RateKgGrapes = 1.25f;
            this.RateKgBerries = 2.80f;

            this.DailyWorkingNorm = 8f;
            this.WeeklyWorkingNorm = 40f;
            this.StandardHourlyIncome = 40f;
        }

        public float ParseToFloat(string weightOfFruit)
        {

            if (float.TryParse(weightOfFruit, out float result))
            {
                return result;
            }
            else
            {
               throw new Exception("invalid weightOfFruit value (string is not float)");
            }
        }

        public float ParseToFloat(int weightOfFruit)
        {
            {
                float result = (float)weightOfFruit;
                return result;
            }
        }

        public float ParseToFloat(double weightOfFruit)
        {
            {
                float result = (float)weightOfFruit;
                return result;
            }
        }

        public float ParseToFloat(long weightOfFruit)
        {
            {
                float result = (float)weightOfFruit;
                return result;
            }
        }

        public float ParseToFloat(decimal weightOfFruit)
        {
            {
                float result = (float)weightOfFruit;
                return result;
            }
        }
    }
}
