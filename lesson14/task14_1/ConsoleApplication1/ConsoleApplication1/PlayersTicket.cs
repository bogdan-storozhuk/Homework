using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PlayersTicket:IPlayersTicket
    {
        readonly int[] _playersTicket = new int[6];
       public void InsertPlayersTicket()
        {
            for (var i = 0; i < _playersTicket.Length; i++)
            {
                Console.WriteLine("Insert Number#{0}:", i + 1);
                _playersTicket[i] = Convert.ToInt32(Console.ReadLine());
                if (_playersTicket[i].ToString().Length != 1) { throw new Exception("Only one letter allowed");}
            }
        }

        public void PrintPlayersTicket()
        {
            for (var i = 0; i < _playersTicket.Length; i++)
            {
                Console.Write("{0},", _playersTicket[i]);
            }
        }

        public int GetLength()
        {
            return _playersTicket.Length;
        }

        public int this[int index]
        {
            get { return _playersTicket[index]; }
        }
    }
}
