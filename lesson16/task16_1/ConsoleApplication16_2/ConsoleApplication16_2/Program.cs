using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            
            StackExample<int> stackExample=new StackExample<int>();
            while (true)
            {
                Console.WriteLine("1-push");
                Console.WriteLine("2-pop");
                Console.WriteLine("3-peek");
                var choise = (Operations) int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case Operations.Push:
                        Console.Write("Type:");
                        stackExample.Push(int.Parse(Console.ReadLine()));
                        break;
                    case Operations.Pop:
                        Console.WriteLine("Extracted value:{0}",stackExample.Pop());
                        Console.ReadKey();
                        break;
                    case Operations.Peek:
                        Console.WriteLine("Peeked value:{0}",stackExample.Peek());
                        Console.ReadKey();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                stackExample.Print();
            }
        }
    }
}
