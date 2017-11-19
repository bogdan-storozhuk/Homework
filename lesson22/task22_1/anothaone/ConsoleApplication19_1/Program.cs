using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using ProtoBuf;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ConsoleApplication19_1
{
    public enum SeriazilationType
    {
        Binary=1,
        Xml,
        Json,
        Protobuf,
        ZipXml
    }

   public enum Choise
    {
        Serialize=1,
        Deserialize
    }
    internal class Program
    {

        private static void Main(string[] args)
        {
            var mobileOperator = new MobileOperator();
            var acc1=new MobileAccount(1, "charley");
            var acc2 = new MobileAccount(2, "lorik");
            var acc3 = new MobileAccount(3, "Dan");
            var acc4 = new MobileAccount(4, "someoneelseiguess");

           
            mobileOperator.AddAccount(acc1);
            mobileOperator.AddAccount(acc2);
            mobileOperator.AddAccount(acc3);
            mobileOperator.AddAccount(acc4);
            mobileOperator.Saving(SeriazilationType.Binary);
            acc1.AddMoney(acc1,50);
            acc2.AddMoney(acc2,20);
            acc3.AddMoney(acc3,60);
            acc4.AddMoney(acc4,80);
            acc1.SendMessage(acc2, "Messagefrom1to2");
            acc1.MakeCall(acc2, "Callfrom1to2");
            acc2.SendMessage(acc3, "Messagefrom2to3");
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
