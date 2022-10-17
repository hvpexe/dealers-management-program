using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.data
{
    public class Account
    {
        private string accName;
        private string pwd;
        private string role;

        public Account(string accName, string pwd, string role)
        {
            this.accName = accName;
            this.pwd = pwd;
            this.role = role;
        }

        public string AccName { get => accName; set => accName = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Role { get => role; set => role = value; }
    }
}
