using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueExample<int> queueExample=new QueueExample<int>();
            while (true)
            {
                Console.WriteLine("1-Enqueue");
                Console.WriteLine("2-Dequeue");
                Console.WriteLine("3-Peek");
                var choise = (Operations) Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case Operations.Enqueue:
                        Console.Write("Type:");
                        queueExample.Engueue(int.Parse(Console.ReadLine()));
                        break;
                    case Operations.Dequeue:
                        Console.WriteLine("Extracted Elem:{0}",queueExample.Dequeue());
                        break;
                    case Operations.Peek:
                        Console.WriteLine("Peeked Elem:{0}", queueExample.Peek());
                        Console.ReadKey();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                queueExample.Print();
            }
        }
    }
}
