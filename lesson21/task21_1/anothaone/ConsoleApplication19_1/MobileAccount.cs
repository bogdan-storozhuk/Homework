using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


namespace ConsoleApplication19_1
{
    public delegate void AccountStateHandler(MobileAccount callReceiver,MobileAccount caller, string message);
    [DataContract]
    [Serializable]
    [ProtoContract]
    public class MobileAccount
    {
        public event AccountStateHandler Call;
        public event AccountStateHandler Message;
        [DataMember]
        [ProtoMember(1)]
        public List<int> AdressKey { get; set; }
        [DataMember]
        [ProtoMember(2)]
        public List<string> AdressValue { get; set; }
        [DataMember]
        [ProtoMember(3)]
        public readonly CallLog _callLogs;
       [DataMember]
       [ProtoMember(4)]
        public int Numerber { get; set; }
        [DataMember]
        [ProtoMember(5)]
        public string Name { get; set; }
        [DataMember]
        [ProtoMember(6)]
        public int Money { get; set; }

        public MobileAccount(int number,string name)
        {
            AdressKey=new List<int>();
            AdressValue=new List<string>();
            _callLogs = new CallLog();
            Numerber = number;
            Name = name;
            Money = 0;
        }

        public MobileAccount()
        {
            _callLogs = new CallLog();
        }

        public void SendMessage(MobileAccount account,string message)
        {
          _callLogs.CoefficientActivity+=0.5;
          Message.Invoke(account,this,message);
        }

        public int GetCallCounts()
        {
            return _callLogs.CallCount;
        }

        public double GetCoefficientActivity()
        {
            return _callLogs.CoefficientActivity;
        }
        public void MakeCall(MobileAccount account,string message)
        {
            _callLogs.CoefficientActivity += 1;
            Call.Invoke(account,this, message);
        }
        public void ReceiveCall(MobileAccount caller, string message)
        {
            int keyindex;
            if (AdressKey != null)
            {
                keyindex = AdressKey.IndexOf(caller.Numerber);
            }
            else
            {
                 keyindex = -1;
            }
            _callLogs.CallCount += 1;
            if (keyindex != -1)
            {
                Console.WriteLine("Received from: {0}", AdressValue[keyindex]);
            }
            else
            {
                Console.WriteLine("Received from: {0}", caller.Numerber);
            }
            Console.WriteLine("Message:  {0}", message);
        }
        public void ReceiveMesagge(MobileAccount caller , string message)
        {
            int keyindex;
            if (AdressKey != null)
            {
                keyindex = AdressKey.IndexOf(caller.Numerber);
            }
            else
            {
                keyindex = -1;
            }
            if (keyindex != -1)
            {
                Console.WriteLine("Received from: {0}", AdressValue[keyindex]);
            }
            else
            {
                Console.WriteLine("Received from: {0}", caller.Numerber);
            }
            Console.WriteLine("Message:  {0}", message);
        }

        public void ReceiveMessage(IOperatorMessage message)
        {
            var type = typeof(IOperatorMessage);
            var attributes = type.GetCustomAttributes(typeof(OperatorMessageAttribute),false);
            if (message is Info)
            {
                foreach (OperatorMessageAttribute attribute in attributes)
                {
                    attribute.MethodforInfo(message.Message);
                }
            }
            else
            {
                foreach (OperatorMessageAttribute attribute in attributes)
                {
                    attribute.MethodforWarn(message.Message);
                }
            }

        }
        public void AddIntoAddressBook(int number, string name)
        {
            AdressKey.Add(number);
            AdressValue.Add(name);
        }
    }


}
