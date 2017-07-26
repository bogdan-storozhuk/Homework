using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class FileReaderWriter
    {
        public static FileHandle OpenForRead(string path)
        {

            return new FileHandle
            {
                FileAccessEnum = FileAccessEnum.Read,
                FileName = path,
                FileSize = 40
            };
        }
        public static FileHandle OpenForWrite(string path)
        {
            return new FileHandle
            {
                FileAccessEnum = FileAccessEnum.Write,
                FileName = path,
                FileSize = 40
            };
        }
        public static FileHandle OpenFile(string path)
        {
            return new FileHandle
            {
                FileAccessEnum = FileAccessEnum.Read | FileAccessEnum.Write,
                FileName = path,
                FileSize = 40
            };
        }
    }
}
