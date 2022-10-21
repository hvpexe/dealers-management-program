using DealersManagementProgram.tool;
using NUnit.Framework;

namespace DealersManagementProgramTesting
{
    [TestFixture(Author = "PhuHV")]
    public class ValidatePasswordTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test, MaxTime(100)]
        [Category("Long")]
        public void Test_Validate_Password_Given_Right_Argument_Returns_True()
        {
            Assert.AreEqual(true, MyTool.validPassword("HellofromTest@123", 7));
            Assert.AreEqual(true, MyTool.validPassword("!@#$%^&*()a1", -7));
            Assert.IsTrue(MyTool.validPassword("1234567890a@", 0));
            Assert.IsTrue(MyTool.validPassword("Hvp3x3@", 7));
        }

        [Test]
        [Category("Short")]
        public void Test_Validate_Password_Given_Password_Not_Long_Enough_Returns_False()
        {
            Assert.AreNotEqual(true, MyTool.validPassword("heLLoT@2", 10));
        }

        [Test]
        [Category("Long")]
        //[Ignore("Test ignore")]
        public void Test_Validate_Password_Given_Wrong_Password_Returns_False()
        {
            Assert.AreNotEqual(true, MyTool.validPassword("qwertyuiop", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("12345$%^", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("123456abc", 6));
            Assert.AreNotEqual(true, MyTool.validPassword("qwerty!@#$", 6));
            Assert.That(MyTool.validPassword("12345678", 6), Is.EqualTo(false));
            Assert.That(MyTool.validPassword("!@#$%^&*()", 6), Is.Not.EqualTo(true));
        }

        [TestCase("qwertyuiop", 6, ExpectedResult = false)]
        [TestCase("12345$", 6, ExpectedResult = false)]
        [TestCase("123456abc", 6, ExpectedResult = false)]
        [TestCase("qwerty!@#$", 6, ExpectedResult = false)]
        public bool Test_Validate_Password_Given_Wrong_Password_Returns_False_Test_Case(string pwd, int len)
        {
            return MyTool.validPassword(pwd, len);
        }


        //phai khai bao static
        static object[] TestCases =
        {
            new object[] {"qwertyuiop", 6},
            new object[] {"12345$", 6},
            new object[] {"123456abc", 6}
        };

        [TestCaseSource(nameof(TestCases))]
        public void Test_Validate_Password_Given_Wrong_Password_Returns_False_Parameterized(string pwd, int len)
        {
            Assert.That(MyTool.validPassword(pwd, len), Is.False);
        }
    }
}