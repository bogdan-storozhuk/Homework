using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    [AttributeUsage(AttributeTargets.Interface,AllowMultiple=false)]
    internal class OperatorMessageAttribute:System.Attribute
    {
        public void MethodforInfo(string message)
        {
            Console.WriteLine("Private Info");
        }

        public void MethodforWarn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("MessagefromOperator{0}",message);
            Console.ForegroundColor=ConsoleColor.Blue;
        }
    }
}
