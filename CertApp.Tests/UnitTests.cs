namespace CertApp.Tests
{
    public class UnitTests
    {
        [Test]
        public void IfAddQuantityWorksCorrectly()
        {
            //arrange
            var locationInMemory = new LocationInMemory("A", "1");
            locationInMemory.AddQuantity("w");
            locationInMemory.AddQuantity("k");
            locationInMemory.AddQuantity("50");

            //act
            //var result = locationInMemory.Quantity;
            var stat = new Statistics();
            var result = stat.Sum;

            //assert
            Assert.AreEqual(85, result);
        }
        [Test]

        public void IfLevelQuantityIndicatorWorksCorrectly()
        {
            //arrange
            var locationInMemory = new LocationInMemory("A", "2");
            locationInMemory.AddQuantity("200");
            locationInMemory.AddQuantity("300");
            locationInMemory.AddQuantity("50");
            var stat = locationInMemory.GetStatistics();

            //act
            var result = stat.Level;

            //assert
            Assert.AreEqual("Medium", result);
        }
    }
}
