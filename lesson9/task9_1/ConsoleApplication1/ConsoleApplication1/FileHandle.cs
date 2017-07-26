using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Flags]
    enum FileAccessEnum
    {
        Read=1,
        Write=2,
    }
    struct FileHandle
    {
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public FileAccessEnum FileAccessEnum { get; set; }
    }       
}
