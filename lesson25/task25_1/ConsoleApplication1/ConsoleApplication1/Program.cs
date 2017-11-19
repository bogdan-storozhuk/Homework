using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var archivator=new Archivator();
            var extractor=new Extractor();
            //var thread = new Thread(archivator.Archive);
            var thread = new Thread(extractor.Extract);
            thread.Start("Root");
            Console.ReadKey();
        }
    }
}
