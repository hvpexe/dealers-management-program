using DealersManagementProgram.tool;

namespace DealersManagementProgramTesting
{
    [TestFixture]
    public class MyToolTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Validate_Password_Given_Right_Argument_Returns_True()
        {
            Assert.AreEqual(true, MyTool.validPassword("HellofromTest@123", 7));
            Assert.AreEqual(true, MyTool.validPassword("hellofromtest@123", 7));
            Assert.AreEqual(true, MyTool.validPassword("Hvp3x3@", 7));
            Assert.AreEqual(true, MyTool.validPassword("1234567890a@", 0));
            Assert.AreEqual(true, MyTool.validPassword("!@#$%^&*()a1", -7));
        }

        [Test]
        public void Test_Validate_Password_Given_Password_Not_Long_Enough_Returns_False()
        {
            Assert.AreEqual(false, MyTool.validPassword("heLLoT@2", 10));
        }

        [Test]
        public void Test_Validate_Password_Given_Wrong_Password_Returns_False()
        {
            Assert.AreNotEqual(true, MyTool.validPassword("12345678", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("qwertyuiop", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("!@#$%^&*()", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("12345$%^", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("123456abc", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("qwerty!@#$", 6));
        }

    }
}