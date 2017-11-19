using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    class MobileOperator
    {
        private int _count;
        List<MobileAccount> _accountArray;


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
            for (int i = 0; i < _count; i++)
            {
                if (callReceiver == _accountArray[i])
                {
                    _accountArray[i].ReceiveMesagge(caller, message);
                }
            }
        }

        public void MakeCallEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (int i = 0; i < _count; i++)
            {
                if (callReceiver == _accountArray[i])
                {
                    _accountArray[i].ReceiveCall(caller, message);
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
    }

}   
    