using DealersManagementProgram.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.data
{
    public class Config
    {
        //se co phan tiep theo
        private static readonly String CONFIG_FILE = "DealerData/config.txt";
        private string _accountFile;
        private string _dealerFile;
        private string _deliveryFile;

        public string AccountFile { get => _accountFile; set => _accountFile = value; }
        public string DealerFile { get => _dealerFile; set => _dealerFile = value; }
        public string DeliveryFile { get => _deliveryFile; set => _deliveryFile = value; }

        public Config()
        {
            ReadData();
        }
        private void ReadData()
        {
            ReadData(CONFIG_FILE);
        }

        public void ReadData(string filename)
        {
            List<string> lines = MyTool.readLineFromFile(filename); //Đã Test Config

            if (lines.Count < 3) throw new IOException("Not enough arguments! "); 

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (line.ToUpper().IndexOf("ACCOUNT") >= 0 && parts.Length == 2) AccountFile = "DealerData/" + parts[1].Trim();
                if (line.ToUpper().IndexOf("DEALER") >= 0 && parts.Length == 2) DealerFile = "DealerData/" + parts[1].Trim();
                if (line.ToUpper().IndexOf("DELIVER") >= 0 && parts.Length == 2) DeliveryFile = "DealerData/" + parts[1].Trim();
            }
            if (String.IsNullOrEmpty(AccountFile)) throw new IOException("Not enough arguments: Missing Account File");
            if (String.IsNullOrEmpty(DealerFile)) throw new IOException("Not enough arguments: Missing Dealer File");
            if (String.IsNullOrEmpty(DeliveryFile)) throw new IOException("Not enough arguments: Missing Delivery File");

            //public static void Main()
            //{
            //    Config cR = new Config();
            //}
        }
    }
}
