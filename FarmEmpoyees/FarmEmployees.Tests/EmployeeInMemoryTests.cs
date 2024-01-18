namespace FarmEmployees.Tests
{
    public class Tests
    {

        [Test]
        public void WhenInputFloatValue_ShouldGetCorrectStatistics()
        {
            // arrange
            var employee = new EmployeeInMemory("Lee", "Wong");
            employee.AddSalary(125.72f);
            employee.AddSalary(.3602f);
            employee.AddSalary(0f);
            employee.AddSalary(-.3602f);
            employee.AddSalary(-125.72f);

            // act
            var statistics = employee.GetStatistics();

            //assert

            Assert.AreEqual(4, statistics.Count);
            Assert.AreEqual(2000, statistics.Sum);
            Assert.AreEqual(50, statistics.HourlyAverage);
            Assert.AreEqual(400, statistics.DaylyAverage);
            Assert.AreEqual(25, statistics.DeviationFromStandardHourlyIncome);

        }
    }
}
        