using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IPlayersTicket
    {
        void InsertPlayersTicket();
        void PrintPlayersTicket();
        int GetLength();
        int this[int index] { get; }

    }
}
