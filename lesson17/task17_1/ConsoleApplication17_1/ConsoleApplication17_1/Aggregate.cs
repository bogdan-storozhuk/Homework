using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17_1
{
   abstract class Aggregate<T>
    {
        public abstract Iterator<T> CreateIterator();
    }
}
