using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class ColorPrinter:Printer
    {
        public override void Print(string inputText)
        {
            Console.WriteLine("{0}-Print(string inputText) method from ColorPrinter",inputText);
        }

        public void Print(string inputText, ConsoleColor color)
        {
            Console.ForegroundColor=color;
            Console.WriteLine("{0}-Print(string inputText,ConsoleColor color) method from ColorPrinter",inputText);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
