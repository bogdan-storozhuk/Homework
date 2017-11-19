using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mobileOperator = new MobileOperator();
            var acc1 = new MobileAccount(1, "charley");
            var acc2 = new MobileAccount(2, "lorik");
            var acc3 = new MobileAccount(3, "Dan");
            var acc4 = new MobileAccount(4, "someoneelseiguess");
            mobileOperator.AddAccount(acc1);
            mobileOperator.AddAccount(acc2);
            mobileOperator.AddAccount(acc3);
            mobileOperator.AddAccount(acc4);
            mobileOperator.AddMoney(acc1, 50);
            mobileOperator.AddMoney(acc2, 20);
            mobileOperator.AddMoney(acc3, 60);
            mobileOperator.AddMoney(acc4, 80);
            acc2.AddIntoAddressBook(1, "charley");
            acc1.SendMessage(acc2, "Messagefrom1to2");
            acc1.MakeCall(acc2, "Callfrom1to2");
            acc1.SendMessage(acc3, "Messagefrom2to3");
            acc2.MakeCall(acc3, "Callfrom2to3");
            acc2.MakeCall(acc3, "Callfrom2to3#2");
            acc4.MakeCall(acc3, "callfrom4to3");
            Console.WriteLine("Most called numbers:");
            
            foreach (var frequentlyCalled in mobileOperator.GetFrequentlyCalledPhoneNumbers())
            {
                Console.Write("{0},", frequentlyCalled);
            }
            Console.WriteLine("\nMost Active Users:");
            foreach (var mostActiveUser in mobileOperator.GetMostActiveUsers())
            {
                Console.Write("{0},", mostActiveUser);
            }
            Console.WriteLine();
    
            Console.ReadKey();
        }
    }
}
