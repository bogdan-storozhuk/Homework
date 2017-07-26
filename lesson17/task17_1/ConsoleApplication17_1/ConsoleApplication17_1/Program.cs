using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate<string> a = new ConcreteAggregate<string>();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            ConcreteIterator<string> i = new ConcreteIterator<string>(a);

            Console.WriteLine("Iterating over collection:");

            var item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            Console.ReadKey();
        }
    }
}
