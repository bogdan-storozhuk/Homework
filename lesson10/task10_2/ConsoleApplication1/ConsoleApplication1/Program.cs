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
            var arrayHandler = new ArrayHandler();
            var finished = false;
            while (!finished)
            {
                Console.WriteLine("1 - Add element");
                Console.WriteLine("2 - Contains");
                Console.WriteLine("3 - Get by element");
                Console.Write("Input:");
                try
                {
                    var choise = (Operations) int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case Operations.Add:
                            Console.Write("Type element:");
                            arrayHandler.Add(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case Operations.Contains:
                            arrayHandler.Contains();
                            break;
                        case Operations.GetByIndex:
                            Console.Write("Type index:");
                            arrayHandler.GetByIndex(Convert.ToInt32(Console.ReadLine()));
                            break;
                        default:
                            finished = true;
                            break;
                    }

                    for (var i = 0; i < arrayHandler.Count; i++)
                    {
                        Console.Write(arrayHandler[i] + " ");
                    }
                    Console.WriteLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Wrong input format.Try again");
                }
            }
        }
    }
}
