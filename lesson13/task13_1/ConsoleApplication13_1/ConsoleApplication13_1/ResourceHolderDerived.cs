using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13_1
{
    class ResourceHolderDerived:ResourceHolderBase,IDisposable
    {
        public void Dispose()
        {
            
        }
    }
}
