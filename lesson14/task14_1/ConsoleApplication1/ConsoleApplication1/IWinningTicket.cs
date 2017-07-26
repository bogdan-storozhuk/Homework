using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IWinningTicket
    {
        void GenerateRandomTicket();
        void PrintWinnersTicket();
        int this[int index] { get;}
    }
}
