using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorPrinter = new ColorPrinter();
            colorPrinter.Print("TEST_TEXT",ConsoleColor.Yellow);
            colorPrinter.Print("TEST_TEXT");
            var photoPrinter = new PhotoPrinter();
            photoPrinter.Print("TEST_TEXT");
            photoPrinter.Print("TEST_TEXT","PHOTO#42");
            Console.ReadKey();
        }
    }
}
