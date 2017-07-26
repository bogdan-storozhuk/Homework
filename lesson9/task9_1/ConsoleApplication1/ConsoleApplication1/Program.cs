using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Console.WriteLine(FileReaderWriter.OpenForRead("path").FileAccessEnum);
            Console.WriteLine(FileReaderWriter.OpenFile("path").FileAccessEnum);
            Console.WriteLine(FileReaderWriter.OpenForWrite("path").FileAccessEnum);
            Console.ReadKey();

        }
    }
}
