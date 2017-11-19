using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication18_1
{
  
    public delegate void AccountStateHandler(MobileAccount callReceiver,MobileAccount caller, string message);
    public class MobileAccount
    {
        public event AccountStateHandler Call;
        public event AccountStateHandler Message;
        Dictionary<int, string> adressBook = new Dictionary<int, string>();
        public int Numerber { get; set; }
        public string Name { get; set; }

        public MobileAccount(int number,string name)
        {
            Numerber = number;
            Name = name;
        }

        public void SendMessage(MobileAccount account,string message)
        {
          Call.Invoke(account,this,message);
        }

        public void MakeCall(MobileAccount account,string message)
        {
            Message.Invoke(account,this, message);
        }
        public void Receive(MobileAccount caller, string message)
        {
            var name = adressBook.Where(p => p.Key == caller.Numerber).Select(p => p.Value).FirstOrDefault();
            if (name==null)
            {
                Console.WriteLine("Received from: {0}", caller.Numerber);
            }
            else
            {
                Console.WriteLine("Received from: {0}", name);
            }
                
            

            Console.WriteLine("Message:  {0}", message);
        }
        public void AddIntoAddressBook(int number, string name)
        {
            adressBook.Add(number, name);
        }
    }
}
