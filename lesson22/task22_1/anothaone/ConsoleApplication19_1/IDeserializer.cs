using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    internal interface IDeserializer
    {
        T BinaryDeserialize<T>(string filePath);
        T XmlDeserialize<T>(string filePath);
        T JsonDeserialize<T>(string filePath);
        T ProtobufDeserialize<T>(string filePath);
    }
}
