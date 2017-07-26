using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DictionaryExample<string,string> dictionaryExample=new DictionaryExample<string, string>();
        
            while (true)
            {
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Remove");
                var choise = (Operations) int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case Operations.Add:
                        Console.Write("Type key:");
                        var key = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Type value:");
                        var value = Console.ReadLine();
                        dictionaryExample.Add(key, value);
                        break;
                    case Operations.Remove:
                        Console.Write("Type key:");
                        if (!dictionaryExample.Remove(Console.ReadLine()))
                        {
                            Console.WriteLine("Key doesn't exist");
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                var key2 = Console.ReadLine();
               Console.WriteLine(dictionaryExample[key2]);
                Console.ReadLine();
                Console.Clear();
                dictionaryExample.Print();
            }
        }
    }
}
