using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication18_1
{
    class MobileOperator
    {

        private int _count;
        MobileAccount[] _accountArray=new MobileAccount[10];
        
        public MobileOperator()
        {
            _count = 0;
        }

        public void AddAccount(MobileAccount account)
        {
            if (_count == _accountArray.Length)
            {
                var tempArray=new MobileAccount[_accountArray.Length+10];
                for (var i = 0; i < _accountArray.Length-1; i++)
                {
                    tempArray[i] = _accountArray[i];
                }
                _accountArray = tempArray;
            }
            _accountArray[_count] = account;
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
                    _accountArray[i].Receive(caller,message);
                }
            }
        }

        public void MakeCallEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (int i = 0; i < _count; i++)
            {
                if (callReceiver == _accountArray[i])
                {
                    _accountArray[i].Receive(caller,message);
                }
            }
        }
    }
}
