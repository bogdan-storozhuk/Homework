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
        private AccountDataBase _accountDataBase;
         private IOperatorMessage _operatorMessage;

        private readonly Serializer _serializer;
        private readonly Deserializer _deserializer;
        private readonly StoreStateToZip _storeStateToZip;
        private readonly RestoreStateFromZip _restoreStateFromZip;

        public MobileOperator()
        {
            _count = 0;
            _accountDataBase = new AccountDataBase();
            _serializer = Serializer.CreateInstace();
            _deserializer=Deserializer.CreateInstace();
            _storeStateToZip = StoreStateToZip.CreateInstace();
            _restoreStateFromZip=RestoreStateFromZip.CreateInstace();
        }

        public void AddAccount(MobileAccount account)
        {
            _accountDataBase.AccountArray.Add(account);
            _accountDataBase.AccountArray[_count].Call += MakeCallEvent;
            _accountDataBase.AccountArray[_count].Message += SendMessageEvent;
            _accountDataBase.AccountArray[_count].MoneyAdding += AddMoneyEvent;
            _count++;
        }

        public void AddMoneyEvent(MobileAccount account, int addMoney)
        {
            account.Money += addMoney;
        }
        public void AttachEventAndCountVar()
        {
            foreach (var account in _accountDataBase.AccountArray)
            {
                account.Call += MakeCallEvent;
                account.Message += SendMessageEvent;
                account.MoneyAdding += AddMoneyEvent;
            }
            _count = _accountDataBase.AccountArray.Count;
        }

        public void SendMessageEvent(MobileAccount callReceiver, MobileAccount caller, string message)
        {
            for (var i = 0; i < _count; i++)
            {
                if (callReceiver == _accountDataBase.AccountArray[i] && caller.Money >= 5)
                {
                    caller.Money -= 5;
                    _accountDataBase.AccountArray[i].ReceiveMesagge(caller, message);
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
                if (callReceiver == _accountDataBase.AccountArray[i] && caller.Money >= 10)
                {
                    caller.Money -= 10;
                    _accountDataBase.AccountArray[i].ReceiveCall(caller, message);
                    if (caller.Money <= 0)
                    {
                        SendWarnToUser(caller);
                    }
                }
            }
        }

        public int[] GetFrequentlyCalledPhoneNumbers()
        {
            return _accountDataBase.AccountArray.OrderBy(account => account.GetCallCounts())
                .Take(5)
                .OrderByDescending(m => m.GetCallCounts())
                .Select(m => m.Numerber)
                .ToArray();
        }

        public int[] GetMostActiveUsers()
        {
            return _accountDataBase.AccountArray.OrderBy(account => account.GetCoefficientActivity())
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
            _operatorMessage = new Info {Message = "Info"};
            account.ReceiveMessage(_operatorMessage);
        }


        public void Desiralize(SeriazilationType seriazilationType)
        {
            switch (seriazilationType)
            {
                case SeriazilationType.Binary:
                    _accountDataBase = _deserializer.BinaryDeserialize<AccountDataBase>("file");
                    AttachEventAndCountVar();
                    break;
                case SeriazilationType.Xml:
                    _accountDataBase.AccountArray = _deserializer.XmlDeserialize<List<MobileAccount>>("file");
                    AttachEventAndCountVar();
                    break;
                case SeriazilationType.Json:
                    _accountDataBase.AccountArray = _deserializer.JsonDeserialize<List<MobileAccount>>("file");
                    AttachEventAndCountVar();
                    break;
                case SeriazilationType.Protobuf:
                    _accountDataBase.AccountArray = _deserializer.ProtobufDeserialize<List<MobileAccount>>("file");
                   AttachEventAndCountVar();
                    break;
                case SeriazilationType.ZipXml:
                    _accountDataBase.AccountArray = _restoreStateFromZip.ZipXmlDeserialize<List<MobileAccount>>("directory", "file");
                    AttachEventAndCountVar();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Saving (SeriazilationType seriazilationType)
        {
           _accountDataBase.Serialize("file",seriazilationType);
        }

        public void Restore(SeriazilationType seriazilationType)
        {
            _accountDataBase.Deserialize(seriazilationType);
            AttachEventAndCountVar();
        }
    }

}

   
    