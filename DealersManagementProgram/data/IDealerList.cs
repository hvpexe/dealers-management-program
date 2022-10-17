using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.data
{
    public interface IDealerList
    {
        public List<Dealer> GetContinuingList();
        public List<Dealer> GetUnContinuingList();
        // search dealer by name or anything else ...
        //i will use this as name
        public void SearchDealer();

        public void AddDealer();
        public void RemoveDealer();
        public void UpdateDealer();
        public void PrintAllDealers();
        public void PrintContinuingDealers();
        public void PrintUnContinuingDealers();
        public void WriteDealerToFile();
        //method trong C# Phai in hoa chu cai dau tien
    }
}
