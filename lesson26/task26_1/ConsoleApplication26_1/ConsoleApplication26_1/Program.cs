using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lineReplacer=new LineReplacer();
            lineReplacer.ReplaceLinesInFiles("dir","changed","word1");
            Console.ReadKey();
        }
    }
}
