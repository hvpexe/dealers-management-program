using DealersManagementProgram.mng;
using DealersManagementProgram.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.data
{
    public class DealerList : List<Dealer>
    {
        Login loginObj = null;
        private String dataFile = "";
        private bool changed;

        public Boolean Changed { get => changed; set => changed = value; }

        public String DataFile { get; set; }

        public DealerList(Login loginObj)
        {
            this.loginObj = loginObj;
        }

        public DealerList()
        {
        }

        // Init tializing basic data files
        public void initWithFile()      //Lam: đã test loadDealerFromFile()
        {
            Config cR = new Config();
            dataFile = cR.DealerFile;
            LoadDealerFromFile();
        }

        //Use Mytool to readline from file 
        // List lines for each line in lines , create a dealer using this line 
        // as parameter add this created Dealer to the list
        public void LoadDealerFromFile()        //Lam: test hàm đọc file -> Test chưa thành công;
                                                //cần thêm Exception khi file sai định dạng hoặc ko tìm thấy tên file
        {
            List<string> lines = MyTool.readLineFromFile(dataFile);
            foreach (string line in lines)
            {
                string[] parts = line.Split(Dealer.SEPERATOR);
                //neu nhu size == 5 thi file duoc doc la Dealer 
                //khac thi ko phai  dealer
                if (parts.Length == 5)
                    this.Add(new Dealer(parts[0]?.Trim(), parts[1]?.Trim(), parts[2]?.Trim(), parts[3]?.Trim(), Boolean.Parse(parts[4]?.Trim())));

            }
        }
        /** Get Continuing List
         *  this method get list of dealer where Dealer is Continued 
         *  (Continuing = true)
         * */
        public DealerList GetContinuingList()   // Lam: đã test
        {
            DealerList dList = new DealerList();
            foreach (Dealer d in this)
            {
                if (d.Continuing) dList.Add(d);
            }

            return dList;
        }

        public DealerList GetUnContinuingList()  // Lam: đã test
        {
            DealerList dList = new DealerList();
            foreach (Dealer d in this)
            {
                if (!d.Continuing) dList.Add(d);
            }
            return dList;
        }
        /* searchDealer by ID */
        public int SearchDealer(String ID)  // Lam: đã test
        {
            foreach (Dealer d in this)
            {
                if (d.ID == ID) return this.IndexOf(d);
            }
            return -1;
        }
        //search theo ID 
        public void SearchDealer()
        {
            string ID = MyTool.readPattern("Please Input The ID you want to Search:", Dealer.ID_FORMAT);//ham nay searh theo format cua dealer cho san

            int pos = SearchDealer(ID);//phan nay tui su dung ham SearchDealer(ID) co san
            if (pos < 0) Console.WriteLine("Not Found!");
            else Console.WriteLine(this[pos]);
        } //bug   //Lam: đã test hàm SearchDealer(String ID)

        public void AddDealer()         //Lam: viết thêm hàm add riêng để test, ko dùng add có sẵn của List.
        {// toi phan code dai
            string ID;
            string name;
            string addr;
            string phone;
            bool continuing;
            int pos;
            do
            {
                ID = MyTool.readPattern("ID of new dealer [D***] ", Dealer.ID_FORMAT);//pattern cua ID la "D\\d{3}"
                ID = ID.ToUpper();
                pos = SearchDealer(ID);
                if (pos >= 0) Console.WriteLine("ID is duplicated!");

            } while (pos >= 0);
            name = MyTool.readNonBlank("Name of the Dealer:").ToUpper();
            addr = MyTool.readNonBlank("Address of the Dealer:").ToUpper();
            phone = MyTool.readPattern("Phone of the Dealer:", Dealer.PHONE_FORMAT);
            continuing = true; //set chua bi xoa
            Dealer d = new Dealer(ID, name, addr, phone, continuing);
            this.Add(d);
            Console.WriteLine("New Dealer has been added");
            changed = true;
        }
        //assign contiuing = false
        public void RemoveDealer()      //Lam : hàm có giao diện ko thể test, cần đổi lại
        {
            string ID;
            int pos;//cai nay cung vay
            Console.WriteLine("ID of Removing dealer");
            ID = Console.ReadLine();
            ID = ID.ToUpper();
            pos = SearchDealer(ID);
            if (pos < 0) Console.WriteLine("Not Found!");
            else
            {
                this[pos].Continuing = false;
                Console.WriteLine("REMOVED!");
                changed = true;

            }

        }//luon luon co bug

        public void UpdateDealer()      //Lam: hàm có giao diện ko thể test, cần đổi lại
        {
            string ID;
            string newName;
            string newAddr;
            string newPhone;
            int pos;
            //vi cai nay cho Input ="" duoc nen ta ko the su dung readnonblank dc
            // ta chi co the su dung readline binh thuong thoi
            Console.Write("Input Dealer ID need Updating..:");
            ID = Console.ReadLine();
            ID = ID.ToUpper();
            pos = SearchDealer(ID);
            if (pos < 0) Console.WriteLine($"Dealer {ID} Not Found!");
            else
            {
                Dealer d = this[pos];
                Console.Write("new name, Enter for omitting: ");
                newName = Console.ReadLine();
                d.Name = newName == "" ? d.Name : newName;

                Console.Write("new address, Enter for omitting: ");
                newAddr = Console.ReadLine();
                d.Addr = newAddr == "" ? d.Addr : newAddr;
                bool checkPhonePattern = false;
                do
                {
                    Console.Write("new Phone, Enter for omitting: ");
                    newPhone = Console.ReadLine();
                    checkPhonePattern = MyTool.validStr(newPhone, Dealer.PHONE_FORMAT);
                    if (String.IsNullOrEmpty(newPhone)) checkPhonePattern = true;
                } while (!checkPhonePattern);
                //check =true chay tiep do..while check=false chay tiep  
                d.Phone = newPhone == "" ? d.Phone : newPhone;
                Console.WriteLine("New Dealer has been Updated");
                changed = true;
            }
            //tai su dung
        }

        public void PrintAllDealers()   //Lam: hàm có giao diện ko thể test, làm thêm hàm getAll để test
        {
            this.ForEach(d => Console.WriteLine(d));
            //su dung for each de in ra tat ca dealer
        }


        public void PrintContinuingDealers() //Lam: đã test GetContinuingList()

        {
            this.GetContinuingList() //phan nay co the sai
                .PrintAllDealers();//phan nay dung 
            //chay ham get continuing 
            //va chay ham o tren 
        }

        public void PrintUnContinuingDealers()  //Lam: đã test GetUnContinuingList()
        {
            this.GetUnContinuingList().PrintAllDealers();
            //giong nhu vay nhung lay continuing =false
        }

        public void WriteDealerToFile()    // Lam: này ko biết test
        {
            List<String> list = new List<string>();
            foreach (Dealer d in this)
            {
                list.Add(d.ToString());
            }
            MyTool.writeFile(dataFile, list);
            Console.WriteLine("Write to file success");
            Console.WriteLine("Reading from file dealers.txt");
            MyTool.readLineFromFile(new Config().DealerFile).ForEach(i => Console.WriteLine(i));
            //coi nhu bai code da xong chuc cac ban viet code thanh cong
        }

    }
}
