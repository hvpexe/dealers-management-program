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
    public class ConfigTest
    {
        Config cr = null;
        string editedTestFile = null;

        [OneTimeSetUp]
        public void Setup()
        {
            /*File of accounts: account.txt
              File of dealers: dealers.txt
              File of delivery notes: deliveries.txt*/
            editedTestFile = @"testfile/configTest.txt";
            if (!File.Exists(editedTestFile))
            File.Create(editedTestFile);
            cr = new Config();

            /*
             crrtest.txt:
             delivery: deliveries.txt
             account: account.txt
             dealers: dealers.txt
            */


        }
        [Test]
        [Category("ReadFile")]
        public void Test_Config_Given_File_Return_Well()
        {
            //expected 
            String[] expected = { "DealerData/account.txt", "DealerData/dealers.txt", "DealerData/deliveries.txt" };
            //Actual
            String[] actual = { cr.AccountFile, cr.DealerFile, cr.DeliveryFile };
            //Test
            for(int i = 0; i < expected.Length; i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i]));
            }
        }
        [Test]
       // [Ignore("Test ignore")]
        [Category("ReadTestFile")]
        public void Test_Config_Given_File_With_Changed_Position_Return_Well()
        {
            StreamWriter sw = new(editedTestFile);
            sw.WriteLine("delivery: deliveries.txt");
            sw.WriteLine("dealers: dealers.txt");
            sw.WriteLine("account: account.txt");
            sw.Close();
            sw.Dispose();
            cr.ReadData(editedTestFile);
            //expected 
            String[] expected = { "DealerData/account.txt", "DealerData/dealers.txt", "DealerData/deliveries.txt" };
            //Actual
            String[] actual = { cr.AccountFile, cr.DealerFile, cr.DeliveryFile };
         
            //Test
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i]));
            }
        }

        [Test]
        // [Ignore("Test ignore")]
        [Category("ReadTestFile")]
        public void Test_Config_Given_Wrong_Argument_Throw_Error()
        {
            //Testcase #1: given only 2 file config this should throw an IOException error
            StreamWriter sw = new(editedTestFile);
            sw.WriteLine("delivery: deliveries.txt");
            sw.WriteLine("dealers: dealers.txt");
            sw.Close();
            sw.Dispose();
            //expected: Throws IOException
            //Test
            Assert.Throws<IOException>(()=>cr.ReadData(editedTestFile));

            //Testcase #2: given wrong file config this should throw an IOException error
            sw = new(editedTestFile);
            sw.WriteLine("File of accounts: account.txt");                            
            sw.WriteLine("File of dealers");//this is an error
            sw.WriteLine("File of delivery notes: deliveries.txt");
            sw.WriteLine("File of config notes: google.txt");
            sw.WriteLine("File of helloworld notes: Hello_World.txt");
            sw.Close();
            //expected: Throws IOException
            //Test
            Assert.Throws<IOException>(() => cr.ReadData(editedTestFile));

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            cr = null;
                if (File.Exists(editedTestFile))
                File.Delete(editedTestFile);
        }
    }
}
