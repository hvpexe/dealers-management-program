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
            Assert.That(MyTool.parseBool(boolStr), Is.False);
        }
    }
}
