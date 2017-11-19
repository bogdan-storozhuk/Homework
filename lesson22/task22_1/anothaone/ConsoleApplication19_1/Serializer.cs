using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;

namespace ConsoleApplication19_1
{
   
    public class Serializer:ISerializer
    {
        private static Serializer _serializer;

        private Serializer()
        {
            
        }

        public  static  Serializer CreateInstace()
        {
            if (_serializer == null)
            {
                _serializer = new Serializer();
                return _serializer;
            }

            return _serializer;
        }
        public  void  BinarySerialize(string filePath, object Object)
        {
            var fileStream=new FileStream(filePath+".dat",FileMode.Create);
            var binaryFormatter=new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, Object);
        }

        void ISerializer.BinarySerialize(string filePath, object Object)
        {
            BinarySerialize(filePath, Object);
        }

        public void XmlSerialize<T>(string filePath, T Object)
        {
            var fileStream = new FileStream(filePath+".xml", FileMode.Create);
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(fileStream, Object);
            fileStream.Close();
        }

        public void JsonSerialize<T>(string filePath, T Object)
        {
            var fileStream = new FileStream(filePath + ".json", FileMode.Create);
            var dataContractJsonSerializer=new DataContractJsonSerializer(typeof(T));
            dataContractJsonSerializer.WriteObject(fileStream,Object);
        }

        public void ProtobufSerialize<T>(string filePath, T Object)
        {
            var file = File.Create(filePath+".bin");
            ProtoBuf.Serializer.Serialize(file,Object);
        }
    }
}
