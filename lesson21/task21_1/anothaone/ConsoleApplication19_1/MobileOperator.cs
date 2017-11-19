using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    [Serializable]
    public class MobileOperator
    {
        [NonSerialized]
        public int Count;
        [NonSerialized]
        public  List<MobileAccount> AccountArray;
        [NonSerialized]
        private IOperatorMessage _operatorMessage;
        public MobileOperator()
        {
            Count = 0;
            AccountArray = new List<MobileAccount>(10);
        }

        public void AddAccount(MobileAccount account)
        {  
            AccountArray.Add(account);
            AccountArray[Count].Call += MakeCallEvent;
            AccountArray[Count].Message += SendMessageEvent;
            Count++;
        }

        public void AttachEventAndCountVar()
        {
            foreach (var account in AccountArray)
            {
                account.Call += MakeCallEvent;
                account.Message += SendMessageEvent;
            }
            Count = AccountArray.Count;
        }
        public void SendMessageEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (var i = 0; i < Count; i++)
            {
                if (callReceiver == AccountArray[i] && caller.Money >= 5)
                {
                    caller.Money -= 5;
                    AccountArray[i].ReceiveMesagge(caller, message);
                    if (caller.Money <= 0)
                    {
                        SendWarnToUser(caller);
                    }
                }
            }
        }

        public void MakeCallEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (var i = 0; i < Count; i++)
            {
                if (callReceiver == AccountArray[i] &&caller.Money>=10)
                {
                     caller.Money -= 10;
                    AccountArray[i].ReceiveCall(caller, message);
                    if (caller.Money <= 0)
                    {
                        SendWarnToUser(caller);
                    }
                }
            }
        }

        public int[] GetFrequentlyCalledPhoneNumbers()
        {
            return AccountArray.OrderBy(account => account.GetCallCounts()).Take(5)
                .OrderByDescending(m => m.GetCallCounts())
                .Select(m => m.Numerber)
                .ToArray();
        }

        public int[] GetMostActiveUsers()
        {
            return AccountArray.OrderBy(account => account.GetCoefficientActivity())
                .Take(5)
                .Select(m => m.Numerber)
                .ToArray();
        }
        public void SendWarnToUser(MobileAccount account)
        {
            _operatorMessage = new Warn {Message = "Warning"};
            account.ReceiveMessage(_operatorMessage);
        }
        public void SendInfoToUser(MobileAccount account)
        {
            _operatorMessage = new Info { Message = "Info" };
            account.ReceiveMessage(_operatorMessage); 
        }

        public void AddMoney(MobileAccount account,int addMoney)
        {
            account.Money += addMoney;
        }

        public MobileAccount[] ToArray()
        {
            return AccountArray.ToArray();
        }
    }

}   
    