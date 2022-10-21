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
            List<string> lines = MyTool.readLineFromFile(CONFIG_FILE);
            try
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (line.ToUpper().IndexOf("ACCOUNT") >= 0) AccountFile = "DealerData/" + parts[1].Trim();
                    if (line.ToUpper().IndexOf("DEALER") >= 0) DealerFile = "DealerData/" + parts[1].Trim();
                    if (line.ToUpper().IndexOf("DELIVER") >= 0) DeliveryFile = "DealerData/" + parts[1].Trim();
                }
            }
            catch (Exception e)
            {

            }
        }
        //public static void Main()
        //{
        //    Config cR = new Config();
        //}
    }
}
