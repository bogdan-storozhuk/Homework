using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace ConsoleApplication11_2
{
  public static class ExtensionMethods
    {
        public static void ColoutPrinterTextOnly(this ColorPrinter colorPrinter, string[] textArray, ConsoleColor color)
        {
            foreach (var text in textArray)
            {
                colorPrinter.Print(text, color);
            }
        }
        public static void PhotoPrinterTextOnly(this PhotoPrinter photoPrinter, string[] textArray)
        {
            foreach (var text in textArray)
            {
                photoPrinter.Print(text);
            }
        }
        public static void PhotoPrinterTextPhoto(this PhotoPrinter photoPrinter, string[] textArray,string[] photoArray)
        {
            for (var i = 0; i < textArray.Length; i++)
            {
                photoPrinter.Print(textArray[i],photoArray[i]);
            }
        }
    }
}
