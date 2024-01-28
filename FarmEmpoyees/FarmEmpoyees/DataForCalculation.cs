using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEmployees
{
    public static class DataForCalculation
    {

        public static string[] Fruits { get; } = { "Apple", "Strawberries", "Grapes", "Berries" };
        public static float RateKgApple { get; private set; }
        public static float RateKgStrawberries { get; private set; }
        public static float RateKgGrapes { get; private set; }
        public static float RateKgBerries { get; private set; }
        public static float DailyWorkingNorm { get; private set; }
        public static float WeeklyWorkingNorm { get; private set; }
        public static float StandardHourlyIncome { get; private set; }

        static DataForCalculation()
        {
            RateKgApple = 0.20f;
            RateKgStrawberries = 1.20f;
            RateKgGrapes = 1.25f;
            RateKgBerries = 2.80f;

            DailyWorkingNorm = 8f;
            WeeklyWorkingNorm = 40f;
            StandardHourlyIncome = 40f;
        }   

        public static float ParseToFloat(string weightOfFruit)
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
    }
}
