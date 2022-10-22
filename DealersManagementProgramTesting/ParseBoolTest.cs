using DealersManagementProgram.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgramTesting
{
    [TestFixture(Author = "QuanHM")]
    public class ParseBoolTest
    {

        [TestCase("y", ExpectedResult = true)]
        [TestCase("yes", ExpectedResult = true)]
        [TestCase("1", ExpectedResult = true)]
        [TestCase("t", ExpectedResult = true)]
        [TestCase("true", ExpectedResult = true)]
        [TestCase("T", ExpectedResult = true)]
        [TestCase("Y", ExpectedResult = true)]
        [TestCase("F", ExpectedResult = false)]
        [TestCase("false", ExpectedResult = false)]
        [TestCase("n", ExpectedResult = false)]
        [TestCase("no", ExpectedResult = false)]
        [TestCase("N", ExpectedResult = false)]
        public bool Test_Parse_Bool_Given_Right_Argument_Returns_True(string boolStr)
        {
            return MyTool.parseBool(boolStr);
        }

        //phai khai bao static
        static object[] TestCases =
        {
            new object[] {"n"},
            new object[] {"N"},
            new object[] {"no"},
            new object[] {"0"},
            new object[] {"false"},
            new object[] {"f"},
            new object[] {"F"},
        };

        [TestCaseSource(nameof(TestCases))]
        public void Test_Parse_Bool_Given_Right_Argument_Returns_False(string boolStr)
        {
            Assert.AreEqual(true, MyTool.parseBool("y"));
            Assert.AreEqual(true, MyTool.parseBool("yes"));
            Assert.AreEqual(true, MyTool.parseBool("1"));
            Assert.AreEqual(true, MyTool.parseBool("Y"));
            Assert.AreEqual(false, MyTool.parseBool("n"));
            Assert.AreEqual(false, MyTool.parseBool("no"));
            Assert.AreEqual(false, MyTool.parseBool("N"));
            Assert.IsTrue(MyTool.parseBool("t"));
            Assert.IsTrue(MyTool.parseBool("test"));
            Assert.That(MyTool.parseBool(boolStr), Is.False);
        }
    }
}
