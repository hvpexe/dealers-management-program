using DealersManagementProgram.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgramTesting;
[TestFixture(Author = "LamVNT")]
public class DealerListTest
{
    private DealerList testList;
    Dealer d1, d2, d3, d4, d5;

    [OneTimeSetUp]
    public void OneTimeSetUp()
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

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        this.d1 = null;
        this.d2 = null;
        this.d3 = null;
        this.d4 = null;
        this.d5 = null;
        this.testList.Clear();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
    }


    [Test]
    [Category("Get")]
    public void Test_GetContinuingList_Given_Right_Agrument_Return_Well()
    {
        // Kiểu DL của expected & actual phải giống nhau thì mới Equal được
        //Dealer expected = new Dealer();

        // expected
        DealerList expected = new DealerList();
        expected.Add(this.d1);
        expected.Add(this.d3);
        expected.Add(this.d5);

        // actual
        DealerList actual = this.testList.GetContinuingList();        
        // test
        Assert.That(expected, Is.EqualTo(actual));
        Assert.That(actual, Has.Exactly(3).Items);
        Assert.That(actual, Does.Contain(d5));
    }

    //[Test]
    //[Category("Get")]
    //public void Test_GetUnContinuingList_Given_Right_Agrument_Return_Well()
    //{
    //    // expected
    //    DealerList expected = new DealerList();
    //    expected.Add(this.d2);
    //    expected.Add(this.d4);
    //    // actual
    //    DealerList actual = this.testList.GetUnContinuingList();
    //    // test
    //    Assert.That(expected, Is.EqualTo(actual));
    //    Assert.That(actual, Does.Not.Contain(d1));
    //}

    [Test]
    [Category("Search")]
    public void Test_SearchDealer_Given_Right_Agrument_Return_Well()
    {
        // expected
        int expected = 0;
        // actual
        int actual = this.testList.SearchDealer("D001");
        // test
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    [Category("Search")]
    public void Test_SearchDealer_Given_Wrong_Agrument_Return_Negative()
    {
        // expected
        int expected = -1;
        // actual
        int actual = this.testList.SearchDealer("D6");
        // test
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    [Category("File")]
    public void Test_LoadDealerFromFile_Given_Right_Agrument_Return_Well()
    {
        // actual
        DealerList actual = new DealerList();
        actual.initWithFile();
        // test
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Unique);
    }
}
