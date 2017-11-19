using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    internal interface ISerializer
    {
        void BinarySerialize<T>(string filePath, T Object);
        void XmlSerialize<T>(string filePath, T Object);
        void JsonSerialize<T>(string filePath, T Object);
        void ProtobufSerialize<T>(string filePath, T Object);
    }
}
