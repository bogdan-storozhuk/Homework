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
            double result = 0;
            Console.WriteLine("Insert first value:");
            double v1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insert operation sign(+,-,*,/,%,^):");
            string op = Console.ReadLine();

            Console.WriteLine("Insert second value:");
            double v2 = Convert.ToDouble(Console.ReadLine());

            switch (op)
            {
                case "+": result = v1 + v2; break;
                case "-": result = v1 - v2; break;
                case "*": result = v1 * v2; break;
                case "/": result = v1 / v2; break;
                case "%": result = v1 % v2; break;
                case "^": result = Math.Pow(v1, v2); break;
            }
            Console.WriteLine("Result: {0} {1} {2} = {3}", v1, op, v2, result);
            Console.ReadKey();
        }
    }
}
