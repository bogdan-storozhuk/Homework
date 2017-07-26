using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17_1
{
   abstract class Iterator<T>
    {
       public abstract T First();

        public abstract T Next();

        public abstract bool IsDone();

        public abstract T CurrentItem();
    }
}
