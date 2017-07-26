using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum EngineTypes
    {
        Benzine,
        Dizil,
    }
    class Engine
    {
        public Engine(EngineTypes enginetype)
        {
            Enginetype = enginetype;
        }
        public EngineTypes Enginetype { get; set; }
    }
}
