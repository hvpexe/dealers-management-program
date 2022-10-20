using DealersManagementProgram.data;
using DealersManagementProgram.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.mng
{
    public class Login
    {
        private Account acc;

        public Account Acc { get => this.acc; set => this.acc = value; }

        public Login(Account acc)
        {
            this.acc = acc;
        }
        public static Account inputAccount()
        {
            Console.WriteLine("Input Account:");
            Console.WriteLine("Username:");
            string accName = Console.ReadLine();
            Console.WriteLine("Password:");
            string pwd = Console.ReadLine();
            Console.WriteLine("User Role:");
            string role = Console.ReadLine();
            return new Account(accName, pwd, role);
        }


        public static void Main(string[] args)
        {
            Account acc = null;
            Boolean cont = false;
            Boolean valid = false;

            do
            {
                AccountChecker accChk = new AccountChecker();
                acc = inputAccount();
                //acc = new Account("E002", "23456789", "ACC-1");
                valid = accChk.check(acc);
                if (!valid)
                    cont = MyTool.readBool("invalid account! Rewrite?");
                if (!valid && !cont) Environment.Exit(0);
            } while (cont);

            Login loginObj = new Login(acc);
            if (acc.Role.Equals("ACC-1", StringComparison.OrdinalIgnoreCase)) Console.WriteLine("Login Success!");
            else
            {
                Console.WriteLine("Login Failed!");
                Console.WriteLine("you are not User ACC-1");
                Environment.Exit(0);
            }


            String[] options = { "Add new dealer", "Search a dealer"
                    , "Remove a dealer", "Update a dealer",
                "Print All dealer", "Print continuing dealer",
                "Print un-continuing dealer", "Write to File" };
            Menu mnu = new Menu(options);
            DealerList dList = new DealerList(loginObj);
            dList.initWithFile();
            int choice = 0;
            do
            {
                Console.WriteLine(mnu.Count);
                choice = mnu.getChoice("Managing Dealer");//chuong tirnh luon luon se co bug
                switch (choice)
                {
                    case 1: dList.AddDealer(); break;
                    case 2: dList.SearchDealer(); break;
                    case 3: dList.RemoveDealer(); break;
                    case 4: dList.UpdateDealer(); break;
                    case 5: dList.PrintAllDealers(); break;
                    case 6: dList.PrintContinuingDealers(); break;
                    case 7: dList.PrintUnContinuingDealers(); break;
                    case 8: dList.WriteDealerToFile(); break;
                    default:
                        if (dList.Changed)
                        {
                            bool res = MyTool.readBool("Data Changed. Write to file?");
                            if (res == true) dList.WriteDealerToFile();
                        }
                        break;
                }
            } while (choice > 0 && choice <= mnu.Count);
            Console.WriteLine("Bye.");
        }
    }
}
