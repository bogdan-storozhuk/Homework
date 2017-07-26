using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class WinningTicket:IWinningTicket
    {
        readonly int[] _winnersTicket=new int[6];
        public void GenerateRandomTicket()
        {
            var random = new Random();
            for (var i = 0; i < _winnersTicket.Length; i++)
            {
                _winnersTicket[i] = random.Next(0, 9);
            }
        }

        public void PrintWinnersTicket()
        {
            for (var i = 0; i < _winnersTicket.Length; i++)
            {
                Console.Write("{0},",_winnersTicket[i]);
            }
        }

        public int this[int index]
        {
            get { return _winnersTicket[index]; }
        }
    }
}
