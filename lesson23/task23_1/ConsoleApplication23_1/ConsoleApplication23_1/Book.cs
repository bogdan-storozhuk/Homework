using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23_1
{
    class Book
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Author { get; set; }

        public Book(string name, string code, string author)
        {
            Name = name;
            Code = code;
            Author = author;
        }
    }
}
