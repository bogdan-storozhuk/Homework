using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    internal class MobileOperator
    {
        private int _count;
        private readonly List<MobileAccount> _accountArray;
        private IOperatorMessage _operatorMessage;
        public MobileOperator()
        {
            _count = 0;
            _accountArray = new List<MobileAccount>(10);
        }

        public void AddAccount(MobileAccount account)
        {  
            _accountArray.Add(account);
            _accountArray[_count].Call += MakeCallEvent;
            _accountArray[_count].Message += SendMessageEvent;
            _count++;
        }
        public void SendMessageEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (var i = 0; i < _count; i++)
            {
                if (callReceiver == _accountArray[i] && caller.Money >= 5)
                {
                    caller.Money -= 5;
                    _accountArray[i].ReceiveMesagge(caller, message);
                    if (caller.Money <= 0)
                    {
                        SendWarnToUser(caller);
                    }
                }
            }
        }

        public void MakeCallEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (var i = 0; i < _count; i++)
            {
                if (callReceiver == _accountArray[i] &&caller.Money>=10)
                {
                     caller.Money -= 10;
                    _accountArray[i].ReceiveCall(caller, message);
                    if (caller.Money <= 0)
                    {
                        SendWarnToUser(caller);
                    }
                }
            }
        }

        public int[] GetFrequentlyCalledPhoneNumbers()
        {
            return _accountArray.OrderBy(account => account.GetCallCounts()).Take(5)
                .OrderByDescending(m => m.GetCallCounts())
                .Select(m => m.Numerber)
                .ToArray();
        }

        public int[] GetMostActiveUsers()
        {
            return _accountArray.OrderBy(account => account.GetCoefficientActivity())
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
    }

}   
    