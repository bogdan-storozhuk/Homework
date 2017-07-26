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
            var list = new MyLinkedList<int>();
            Operations op;
            while (true)
            {
                Console.WriteLine("1-Add");
                Console.WriteLine("2-RemoveFirst");
                Console.WriteLine("3-RemoveLast");
                Console.WriteLine("4 -Contains");
                list.Print();
                Console.WriteLine();
                op = (Operations) int.Parse(Console.ReadLine());
                switch (op)
                {
                    case Operations.Add:
                        Console.Write("Enter:");
                        list.Add(int.Parse(Console.ReadLine()));
                        break;
                    case Operations.RemoveFirst:
                        list.RemoveFirst();
                        break;
                    case Operations.RemoveLast:
                        list.RemoveLast();
                        break;
                    case Operations.Contains:
                        Console.Write("Type:");
                        if (list.Contains(int.Parse(Console.ReadLine())))
                        {
                            Console.WriteLine("Exist");
                        }
                        else 
                        {
                            Console.WriteLine("Doesn't exist");
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
