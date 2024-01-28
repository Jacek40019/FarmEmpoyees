namespace FarmEmployees.Tests
{
    public class DataForCalculationTests
    {
        [Test]
        public void WhenStringParseToFloat_ShouldGetCorrectValueOrException()
        {
            // arrange
            // var data = new DataForCalculation();
            
            // act
            var result1 = DataForCalculation.ParseToFloat("-3,14");
            var result2 = DataForCalculation.ParseToFloat("0");
            var result3 = DataForCalculation.ParseToFloat("3,14");
            var result4 = DataForCalculation.ParseToFloat("1,004");
            var result5 = DataForCalculation.ParseToFloat("1,005");
            
            var exception = Assert.Throws<Exception>(() => DataForCalculation.ParseToFloat("abc"));


            //assert
            Assert.AreEqual(-3.14f, result1);
            Assert.AreEqual(0f, result2);
            Assert.AreEqual(3.14f, result3);
            Assert.AreEqual(1.004f, result4);
            Assert.AreEqual(1.005f, result5);

            Assert.AreEqual("invalid weightOfFruit value (string is not float)", exception.Message, "Exception message is not as expected");
        }        
    }
}


