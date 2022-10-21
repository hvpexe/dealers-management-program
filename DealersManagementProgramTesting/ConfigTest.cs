using DealersManagementProgram.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgramTesting
{
    [TestFixture(Author = "BinhNT")]
    public class ConfigClassTest
    {
        Config cr = null;
        [SetUp]
        public void Setup()
        {
            /*File of accounts: account.txt
              File of dealers: dealers.txt
              File of delivery notes: deliveries.txt*/
             cr = new Config();
        }
        [Test]
        [Category("File")]
        public void Test_Config_() { 
        
        }
        [Test]
        [Category("ReadFile")]
        public void Test_Config_Given_Right_File_Name()
        {   //expected 
            String[] expected = { "DealerData/account.txt", "DealerData/dealers.txt", "DealerData/deliveries.txt" };
            //Actual
            String[] actual = { cr.AccountFile, cr.DealerFile, cr.DeliveryFile };
            //Test
            for(int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
