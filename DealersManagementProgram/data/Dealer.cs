using DealersManagementProgram.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.data
{
    public class Dealer : IComparer<Dealer>
    {
        public const char SEPERATOR = ',';
        public const string ID_FORMAT = "D\\d{3}";
        public const string PHONE_FORMAT = "\\d{9}|\\d{11}";
        private string id;
        private string name;
        private string addr;
        private string phone;
        private bool continuing;
        // co sai gi chi tui voi tui moi hoc thoi <3 <3 <3
        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Addr { get => addr; set => addr = value; }
        public string Phone { get => phone; set => phone = value; }
        public bool Continuing { get => continuing; set => continuing = value; }

        public Dealer(string id, string name, string addr, string phone, bool continuing)
        {
            this.id = id;
            this.name = name;
            this.addr = addr;
            this.phone = phone;
            this.continuing = continuing;
        }

        public int Compare(Dealer d1, Dealer d2)
        {
            return d1.id.CompareTo(d2.id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Dealer dealer &&
                   ID == dealer.ID;
        }
        public Dealer(String line)
        {
            String[] parts = line.Split(Dealer.SEPERATOR + "");
            id = parts[0].Trim();
            name = parts[1].Trim();
            addr = parts[2].Trim();
            phone = parts[3].Trim();
            continuing = MyTool.parseBool(parts[4]);
        }
        public override string ToString()
        { //ID 1 name 2 addr 3 phone 4 continuing
            // size == 5 
            return ID + SEPERATOR + name + SEPERATOR +
                addr + SEPERATOR + phone + SEPERATOR +
                continuing + "\n";
        }
    }
}
