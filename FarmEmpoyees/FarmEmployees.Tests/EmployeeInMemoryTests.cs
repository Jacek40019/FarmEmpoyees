using FarmEmployees;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmEmployees.Tests
{
    public class Tests
    {

        [Test]
        public void WhenInputFloatPositiveOrZeroValue_ShouldGetCorrectStatistics()
        {
            // arrange
            var employee = new EmployeeInMemory("Lee", "Wong");
            employee.AddSalary(1197.19f);
            employee.AddSalary(.3602f);
            employee.AddSalary(0f);
            employee.AddSalary(802.4498f);
                                  
            // act
            var statistics = employee.GetStatistics();

            //assert
            Assert.AreEqual(4, statistics.Count);
            Assert.AreEqual(2000, statistics.Sum);
            Assert.AreEqual(50, statistics.HourlyAverage);
            Assert.AreEqual(400, statistics.DaylyAverage);
            Assert.AreEqual(25, statistics.DeviationFromStandardHourlyIncome);
                      
        }

        [Test]
        public void WhenInputFloatNegativeValue_ShouldGetException()
        {
            // arrange
            var employee = new EmployeeInMemory("Lee", "Wong");

            // act
            var ex = Assert.Throws<Exception>(() => employee.AddSalary(-0.3602f));
            ex = Assert.Throws<Exception>(() => employee.AddSalary(-.12f));                     
            
            //assert
            Assert.AreEqual("invalid weightOfFruit value (negative value is not allowed)", ex.Message, "Exception message is not as expected");
            Assert.AreEqual("invalid weightOfFruit value (negative value is not allowed)", ex.Message, "Exception message is not as expected");

        }
    }
}
