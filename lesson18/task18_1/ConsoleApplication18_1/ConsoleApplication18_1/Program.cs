using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication18_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mobileOperator=new MobileOperator();
            var acc1 = new MobileAccount(1,"charley");
            var acc2 = new MobileAccount(2,"lorik");
            var acc3 = new MobileAccount(3,"Dan");
            var acc4 = new MobileAccount(4, "someoneelseiguess");
            mobileOperator.AddAccount(acc1);
            mobileOperator.AddAccount(acc2);
            mobileOperator.AddAccount(acc3);
            acc2.AddIntoAddressBook(1, "charley");
            acc1.SendMessage(acc2, "Messagefrom1to2");
            acc1.MakeCall(acc2, "Callfrom1to2");
            acc1.SendMessage(acc3, "Messagefrom2to3");
            Console.ReadKey();
           
        }
    }
}
