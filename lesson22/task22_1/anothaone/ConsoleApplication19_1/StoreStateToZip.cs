using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication19_1
{
    [Serializable]
    class StoreStateToZip
    {
        private static StoreStateToZip _storeStateToZip;
        private readonly Serializer _serializer = Serializer.CreateInstace();

        private StoreStateToZip()
        {
            
        }

        public  static  StoreStateToZip CreateInstace()
        {
            if (_storeStateToZip == null)
            {
                _storeStateToZip = new StoreStateToZip();
                return _storeStateToZip;
            }

            return _storeStateToZip;
        }
        public void ZipXmlSerialize<T>(string tempDirectoryName, string fileName, T Object)
        {
            if (File.Exists(fileName + ".zip"))
            {
                File.Delete(fileName + ".zip");
            }

            Directory.CreateDirectory(tempDirectoryName);
            _serializer.XmlSerialize(string.Format("{0}/{1}", tempDirectoryName, fileName),Object);
            ZipFile.CreateFromDirectory(tempDirectoryName, fileName + ".zip");
            var files = Directory.GetFiles(tempDirectoryName);

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            Directory.Delete(tempDirectoryName);
        }
    }
}
