using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ConsoleApplication19_1
{
    [Serializable]
    public class AccountDataBase
    {
        public List<MobileAccount> AccountArray { get; set; }
        [NonSerialized]
        private Serializer _serializer = Serializer.CreateInstace();
        [NonSerialized]
        private Deserializer _deserializer= Deserializer.CreateInstace();
        [NonSerialized]
        private StoreStateToZip _storeStateToZip = StoreStateToZip.CreateInstace();
        [NonSerialized]
        private RestoreStateFromZip _restoreStateFromZip = RestoreStateFromZip.CreateInstace();
        public AccountDataBase()
        {
            AccountArray = new List<MobileAccount>(10);
        }

        public void Serialize(string path, SeriazilationType type) 
        {
            switch (type)
            {
                case SeriazilationType.Binary:
                    _serializer.BinarySerialize("file", AccountArray);
                    break;
                case SeriazilationType.Xml:
                    _serializer.XmlSerialize("file", AccountArray);
                    break;
                case SeriazilationType.Json:
                    _serializer.JsonSerialize("file", AccountArray);
                    break;
                case SeriazilationType.Protobuf:
                    _serializer.ProtobufSerialize("file", AccountArray);
                    break;
                case SeriazilationType.ZipXml:
                    _storeStateToZip.ZipXmlSerialize("directory", "file", AccountArray);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Deserialize(SeriazilationType type)
        {
            switch (type)
            {
                case SeriazilationType.Binary:
                    AccountArray = _deserializer.BinaryDeserialize<List<MobileAccount>>("file");
                    break;
                case SeriazilationType.Xml:
                    AccountArray = _deserializer.XmlDeserialize<List<MobileAccount>>("file");
                    break;
                case SeriazilationType.Json:
                   AccountArray = _deserializer.JsonDeserialize<List<MobileAccount>>("file");
                    break;
                case SeriazilationType.Protobuf:
                    AccountArray = _deserializer.ProtobufDeserialize<List<MobileAccount>>("file");
                    break;
                case SeriazilationType.ZipXml:
                    AccountArray = _restoreStateFromZip.ZipXmlDeserialize<List<MobileAccount>>("directory", "file");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }   
    }
}
