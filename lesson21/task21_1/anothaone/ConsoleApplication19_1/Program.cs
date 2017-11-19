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

namespace ConsoleApplication19_1
{
    internal enum SeriazilationType
    {
        Binary=1,
        Xml,
        Json,
        Protobuf,
    }

    internal enum Choise
    {
        Serialize=1,
        Deserialize
    }
    internal class Program
    {

        private static void Main(string[] args)
        {
            var mobileOperator = new MobileOperator();
            var serialize=new Serialize();
            var deserializer=new Deserializer();
            Console.WriteLine("Select:1-Serialize,2-Deserialize");
            var choise =(Choise)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select format:1-Binary,2-Xml,3-Json,4-Protobuf");
            var type = (SeriazilationType) Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case Choise.Serialize:
                    mobileOperator.AddAccount(new MobileAccount(1, "charley"));
                    mobileOperator.AddAccount(new MobileAccount(2, "lorik"));
                    mobileOperator.AddAccount(new MobileAccount(3, "Dan"));
                    mobileOperator.AddAccount(new MobileAccount(4, "someoneelseiguess"));
                    mobileOperator.AccountArray[1].AddIntoAddressBook(1, "charley");
                    switch (type)
                    {
                        case SeriazilationType.Binary:
                            serialize.BinarySerialize("file",mobileOperator.AccountArray);
                            break;
                        case SeriazilationType.Xml:
                            serialize.XmlSerialize("file",mobileOperator.AccountArray);
                            break;
                        case SeriazilationType.Json:
                            serialize.JsonSerialize("file",mobileOperator.AccountArray);
                            break;
                        case SeriazilationType.Protobuf:
                            serialize.ProtobufSerialize("file",mobileOperator.AccountArray);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case Choise.Deserialize:
                    switch (type)
                    {
                        case SeriazilationType.Binary:
                           mobileOperator.AccountArray = deserializer.BinaryDeserialize<List<MobileAccount>>("file");
                            mobileOperator.AttachEventAndCountVar();
                            break;
                        case SeriazilationType.Xml:
                            mobileOperator.AccountArray = deserializer.XmlDeserialize<List<MobileAccount>>("file");
                            mobileOperator.AttachEventAndCountVar();
                            break;
                        case SeriazilationType.Json:
                            mobileOperator.AccountArray = deserializer.JsonDeserialize<List<MobileAccount>>("file");
                            mobileOperator.AttachEventAndCountVar();
                            break;
                        case SeriazilationType.Protobuf:
                            mobileOperator.AccountArray = deserializer.ProtobufDeserialize<List<MobileAccount>>("file");
                            mobileOperator.AttachEventAndCountVar();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            mobileOperator.AddMoney(mobileOperator.AccountArray[0],50);
            mobileOperator.AddMoney(mobileOperator.AccountArray[1], 20);
            mobileOperator.AddMoney(mobileOperator.AccountArray[2], 60);
            mobileOperator.AddMoney(mobileOperator.AccountArray[3], 80);
            mobileOperator.AccountArray[0].SendMessage(mobileOperator.AccountArray[1], "Messagefrom1to2");
            mobileOperator.AccountArray[0].MakeCall(mobileOperator.AccountArray[1], "Callfrom1to2");
            mobileOperator.AccountArray[1].SendMessage(mobileOperator.AccountArray[2], "Messagefrom2to3");
            mobileOperator.AccountArray[1].MakeCall(mobileOperator.AccountArray[2], "Callfrom2to3");
            mobileOperator.AccountArray[1].MakeCall(mobileOperator.AccountArray[2], "Callfrom2to3#2");
            mobileOperator.AccountArray[3].MakeCall(mobileOperator.AccountArray[2], "callfrom4to3");
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
