using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library("file.xml");
            library.Add(new Book("Hobbit","code","Rouling"));
            library.Add(new Book("Harry Potter", "123", "Rouling"));
            library.Select("ArrayOfBooks / book / name");
            library.Search("Harry Potter");
            library.Delete("Hobbit");
            library.Delete("Harry Potter");
            Console.ReadKey();
        }
    }
}
