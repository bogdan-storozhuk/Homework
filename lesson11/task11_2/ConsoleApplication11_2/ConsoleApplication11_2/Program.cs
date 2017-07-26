using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace ConsoleApplication11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorPrinter = new ColorPrinter();
            var photoPrinter = new PhotoPrinter();
            var textArray = new[]{"Text1","Text2","Text3","Text4","Text5"};
            var photoArray = new[] {"Photo1", "Photo2", "Photo3", "Photo4", "Photo5"};
            colorPrinter.ColoutPrinterTextOnly(textArray, ConsoleColor.Cyan);
            photoPrinter.PhotoPrinterTextOnly(textArray);
            photoPrinter.PhotoPrinterTextPhoto(textArray,photoArray);
            Console.ReadKey();
        }
    }
}
