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
        [Test]
        [Category("Long")]
        public void Test_Parse_Bool_Given_Right_Argument_Returns_Well()
        {
            Assert.AreEqual(true, MyTool.parseBool("y"));
            Assert.AreEqual(true, MyTool.parseBool("yes"));
            Assert.AreEqual(true, MyTool.parseBool("1"));
            Assert.IsTrue(MyTool.parseBool("t"));
            Assert.IsTrue(MyTool.parseBool("test"));
        }
    }
}
