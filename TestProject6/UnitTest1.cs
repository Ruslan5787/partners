using Master_Paul_App;

namespace TestProject6
{
    public class Tests
    {
        [SetUp]
        public void Setup ()
        {
        }

        [Test]
        public void Test1 ()
        {
            int result = MainWindow.CalculateDiscount(1000);

            Assert.AreEqual(result, 0);
        }
        
        [Test]
        public void Test2 ()
        {
            int result = MainWindow.CalculateDiscount(40000);

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void Test3 ()
        {
            int result = MainWindow.CalculateDiscount(93000);

            Assert.AreEqual(result, 10);
        }

        [Test]
        public void Test4 ()
        {
            int result = MainWindow.CalculateDiscount(1000000);

            Assert.AreEqual(result, 15);
        }

    }
}