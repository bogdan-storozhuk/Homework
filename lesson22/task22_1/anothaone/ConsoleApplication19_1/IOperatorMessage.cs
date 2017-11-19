using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19_1
{
    [OperatorMessage]
    public interface IOperatorMessage
    {
        string Message { get; set; }
    }
}

