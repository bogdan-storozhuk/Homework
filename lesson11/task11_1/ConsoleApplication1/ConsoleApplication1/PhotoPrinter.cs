using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class PhotoPrinter :Printer
    {
        public override void Print(string text)
        {
            Console.WriteLine("{0}-Print(string text) method from PhotoPrinter", text);
        }

        public void Print(string text, string photo)
        {
            Console.WriteLine("Text:{0},Photo:{1}-Print(string text,string photo) method from PhotoPrinter", text,photo);
        }
    }
}
