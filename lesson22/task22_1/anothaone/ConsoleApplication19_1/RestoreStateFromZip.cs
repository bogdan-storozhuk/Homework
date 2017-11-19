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
    class RestoreStateFromZip
    {
        private readonly Deserializer _deserializer;
        private static RestoreStateFromZip _restoreStateFromZip;

        private RestoreStateFromZip()
        {
            _deserializer = Deserializer.CreateInstace();
        }

        public  static  RestoreStateFromZip CreateInstace()
        {
            if (_restoreStateFromZip == null)
            {
                _restoreStateFromZip = new RestoreStateFromZip();
                return _restoreStateFromZip;
            }

            return _restoreStateFromZip;
        }
        public T ZipXmlDeserialize<T>(string tempDirectoryName, string fileName)
        {
            ZipFile.ExtractToDirectory(fileName + ".zip", tempDirectoryName);
            var temp = _deserializer.XmlDeserialize<T>(string.Format("{0}/{1}",tempDirectoryName,fileName));
            var files = Directory.GetFiles(tempDirectoryName);

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            Directory.Delete(tempDirectoryName);
            return temp;
        }
    }
}
