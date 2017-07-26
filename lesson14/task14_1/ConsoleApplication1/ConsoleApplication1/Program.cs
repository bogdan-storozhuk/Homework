using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var winningTicket = new WinningTicket();
            var playersTicket = new PlayersTicket();
            winningTicket.GenerateRandomTicket();
            winningTicket.PrintWinnersTicket();
            Console.WriteLine();
            try
            {
                playersTicket.InsertPlayersTicket();
                for (var i = 0; i < playersTicket.GetLength(); i++)
                {
                    if (playersTicket[i] != winningTicket[i])
                    {
                        Console.WriteLine("You loose bruh");
                        break;
                    }
                    if (i == playersTicket.GetLength() && playersTicket[i] == winningTicket[i])
                    {
                        Console.WriteLine("You win!!!!!");
                        
                    }
                }
                winningTicket.PrintWinnersTicket();
                Console.WriteLine();
                playersTicket.PrintPlayersTicket();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Wrong Format");
            }
            catch (Exception e)
            {
                Console.WriteLine("Only one letter allowed");
            }
            Console.ReadKey();
        }
    }
}
