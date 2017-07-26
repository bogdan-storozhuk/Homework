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
        int _count;
         MobileAccount[] numbersBook=new MobileAccount[10];
        public event AccountStateHandler Call;
        public event AccountStateHandler Message;
        public int Numerber { get; set; }
        public string Name { get; set; }

        public MobileAccount(int number,string name)
        {
            Numerber = number;
            Name = name;
            _count = 0;
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
            for (int i = 0; i <= _count; i++)
            {

                if (int.Equals(numbersBook[i].Numerber,caller.Numerber))
                {
                    Console.WriteLine("Received from: {0}", caller.Name);
                    break;
                }
                else if (i == _count)
                {
                    Console.WriteLine("Received from: {0}", caller.Numerber);
                }
            }

            Console.WriteLine("Message:  {0}", message);
        }
        public void AddIntoNumbersBook(MobileAccount account)
        {
            if (_count == numbersBook.Length)
            {
                var tempArray = new MobileAccount[numbersBook.Length + 10];
                for (var i = 0; i < numbersBook.Length - 1; i++)
                {
                    tempArray[i] = numbersBook[i];
                }
                numbersBook = tempArray;
            }
            numbersBook[_count] = account;
            _count++;
        }
    }
}
