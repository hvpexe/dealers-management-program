using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealersManagementProgram.mng
{
    public class Menu : List<string>
    {
        public Menu()
        {
        }
        //Potential fix
        //vi minh ko biet cach de extend ArrayList
        // nen minh cho no thanh 1 bien trong class Menu luon
        //nhu vay ko bi van de nua
        public Menu(string[] items)
        {
            foreach (string item in items)
            {
                this.Add(item);
            }
        }

        public int getChoice(string title)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine(title);
            foreach (string item in this)
            {
                Console.WriteLine($"{this.IndexOf(item) + 1}- {item}");
            }
            Console.WriteLine("Other for Quit!");
            int choice = 0;
            bool check = false;
            //do while cho toi khi choice bang 1..size cua list
            check = false;
            Console.Write($"Choose[1..{this.Count}]:");
            //thieu readline 
            choice = Int32.Parse(Console.ReadLine());
            if (choice >= 1 && choice <= this.Count) check = true;

            return choice;
        }
    }
}
