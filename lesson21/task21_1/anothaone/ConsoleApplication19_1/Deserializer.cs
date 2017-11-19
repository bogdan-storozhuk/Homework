using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;

namespace ConsoleApplication19_1
{
    internal class Deserializer:IDeserializer
    {
        public T BinaryDeserialize<T>(string filePath)
        {
            var fileStream = new FileStream(filePath + ".dat", FileMode.OpenOrCreate);
            var binaryFormatter=new BinaryFormatter();
            return (T) binaryFormatter.Deserialize(fileStream);
        }
        public T XmlDeserialize<T>(string filePath)
        {
            var fileStream = new FileStream(filePath + ".xml", FileMode.OpenOrCreate);
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(fileStream);
        }
        public T JsonDeserialize<T>(string filePath)
        {
            var fileStream = new FileStream(filePath + ".json", FileMode.OpenOrCreate);
            var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
            return (T) dataContractJsonSerializer.ReadObject(fileStream);
        }
        public T ProtobufDeserialize<T>(string filePath)
        {
            var file = File.OpenRead(filePath + ".bin");
            return  Serializer.Deserialize<T>(file);
        }
    }
}
