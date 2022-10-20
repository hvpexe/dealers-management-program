using DealersManagementProgram.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgramTesting
{
    [TestFixture(Author = "PhuHV")]
    public class AccountCheckerTest
    {
        private AccountChecker aChk;
        private Account acc;
        [SetUp]
        public void Setup()
        {
            aChk = new AccountChecker();
        }

        [Test]
        //[Ignore("Test ignore")]
        public void Test_AccountChecker_Given_Right_BOSS_Account_Returns_True()
        {
            acc = new Account("E001", "12345678", "BOSS");
            Assert.That(aChk.check(acc), Is.True);
        }

        [Test]
        public void Test_AccountChecker_Given_Right_ACC_1_Account_Returns_True()
        {
            acc = new Account("E002", "23456789", "ACC-1");
            Assert.That(aChk.check(acc), Is.True);

            acc = new Account("E003", "34567890", "ACC-2");
            Assert.That(aChk.check(acc), Is.True);
        }

        [Test]
        public void Test_AccountChecker_Given_Non_Exist_Account_Returns_False()
        {
            acc = new Account("E100", "123456789", "ACC-1");
            Assert.That(aChk.check(acc), Is.False);
        }

        [Test]
        public void Test_AccountChecker_Given_Empty_Info_Account_Returns_False()
        {
            acc = new Account("", "", "");
            Assert.That(aChk.check(acc), Is.False);

            acc = new Account("E002", "", "");
            Assert.That(aChk.check(acc), Is.False);

            acc = new Account("", "23456789", "");
            Assert.That(aChk.check(acc), Is.False);

            acc = new Account("", "", "ACC-1");
            Assert.That(aChk.check(acc), Is.False);
        }
    }
}
