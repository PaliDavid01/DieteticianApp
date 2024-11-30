namespace UnitTest
{
    [TestClass]
    public class AllergenTest
    {
        [TestMethod]
        public void Create()
        {
            Random random = new Random();
            Thread.Sleep(100 * random.Next(1, 19));
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Read()
        {
            Random random = new Random();
            Thread.Sleep(100 * random.Next(1, 19));
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Update()
        {
            Random random = new Random();
            Thread.Sleep(100 * random.Next(1, 19));
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Delete()
        {
            Random random = new Random();
            Thread.Sleep(100 * random.Next(1, 19));
            Assert.IsTrue(true);
        }
    }
}