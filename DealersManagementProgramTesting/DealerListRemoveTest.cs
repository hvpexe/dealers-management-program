using DealersManagementProgram.data;
using DealersManagementProgram.tool;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgramTesting
{
    [TestFixture]
    public class DealerListRemoveTest
    {
        private DealerList testList;
        Dealer d1, d2, d3, d4, d5;
        const string inputFile = @"DealerData/testing/RemoveDealerInput.txt";
        const string outputFile = @"DealerData/testing/RemoveDealerOutput.txt";
        StreamReader input = null;
        StreamWriter output = null;
        TextReader In = Console.In;
        TextWriter Out = Console.Out;
        [SetUp]
        public void Setup()
        {
            this.d1 = new Dealer("D001", "D1", "HCM", "0911111111", true);
            this.d2 = new Dealer("D002", "D2", "HCM", "0911111111", false);
            this.d3 = new Dealer("D003", "D3", "HCM", "0911111111", true);
            this.d4 = new Dealer("D004", "D4", "HCM", "0911111111", false);
            this.d5 = new Dealer("D005", "D5", "HCM", "0911111111", true);
            this.testList = new DealerList();
            this.testList.Add(d1);
            this.testList.Add(d2);
            this.testList.Add(d3);
            this.testList.Add(d4);
            this.testList.Add(d5);
            
            
        }
        [Test]
        [Category("Remove")]
        public void Test_RemoveDealer_Given_Right_Agrument_Return_Well()
        {

            //setup
            DealerList dealerList = new DealerList();
            dealerList.Add(this.d1);
            dealerList.Add(this.d2);
            dealerList.Add(this.d3);
            dealerList.Add(this.d4);
            dealerList.Add(this.d5);
            input = new(inputFile);
            output = new(outputFile);
            Console.SetIn(input);
            Console.SetOut(output);
            // test #1: removing D001 and D003 is expected false
            dealerList.RemoveDealer();//D001
            dealerList.RemoveDealer();//D022
            dealerList.RemoveDealer();//D003
            Console.In.Close();
            Console.Out.Close();
            List<String> lines = MyTool.readLineFromFile(outputFile);

            Assert.That(dealerList[0].Continuing, Is.False);
            Assert.That(dealerList[2].Continuing, Is.False);

            // test #2: removing D022 Expected REMOVED!, Not Found!, REMOVED!
            lines = MyTool.readLineFromFile(outputFile);
            Assert.That(lines[1], Is.EqualTo("REMOVED!"));
            Assert.That(lines[3], Is.EqualTo("Not Found!"));
            Assert.That(lines[5], Is.EqualTo("REMOVED!"));
        }
        [TearDown]
        public void TearDown()
        {
            Console.SetIn(In);
            Console.SetOut(Out);
            Console.In?.Close();
            Console.Out?.Close();
            input.Close();
            output.Close();
        }
    }
}
