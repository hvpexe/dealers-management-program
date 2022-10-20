using DealersManagementProgram.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.data
{
    public class AccountChecker
    {
        private string accFile;
        internal static string SEPERATOR = ",";
        public AccountChecker()
        {
            setupAccFile();
        }

        private void setupAccFile()
        {
            Config cR = new Config();
            accFile = cR.AccountFile;

        }

        public Boolean check(Account acc)
        {
            //Doc tung line co trong file
            List<string> lines = MyTool.readLineFromFile(accFile);
            //doc tung line
            //cai foreach nay tui chua xai dc
            foreach (string line in lines)
            {
                String[] parts = line.Split(SEPERATOR);
                if (parts.Length < 3) return false;
                if (parts[0].Equals(acc.AccName, StringComparison.OrdinalIgnoreCase)
                    && parts[1].Equals(acc.Pwd) &&
                        parts[2].Equals(acc.Role, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
