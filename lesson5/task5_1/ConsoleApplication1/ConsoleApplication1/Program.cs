using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum Figures
    {
        Triangle,
        Square,
        Romb,
    }
    class Program
    {
        public static void DrawSquare()
        {
            Console.WriteLine("Set size:");
            var size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <=size; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
        public static void DrawTriangle()
        {
            Console.WriteLine("Set size:");
            var size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
           
        }
        public static void DrawRomb()
        {
            Console.WriteLine("Set size:");
            var size = Convert.ToInt32(Console.ReadLine());
            int firstCycleLength = size / 2;
            int secondCycleLength = firstCycleLength + 1;
            int mid = firstCycleLength;
            int maxValue = secondCycleLength;
            for (int i = 0; i < firstCycleLength; i++)
            {
                for (int j = 0; j < mid; j++)
                {
                    Console.Write(' ');
                }
                for (int k = mid; k < maxValue; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                maxValue++;
                mid--;
            }
            for (int i = 0; i < secondCycleLength; i++)
            {
                for (int j = 0; j < mid; j++)
                {
                    Console.Write(' ');
                }
                for (int k = mid; k < maxValue; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                maxValue--;
                mid++;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Select figure:Triangle, Square, Romb");
            Figures figure;
            if (!Enum.TryParse(Console.ReadLine(), out figure))
            {
                Console.WriteLine("wrong input");
                Console.ReadKey();
                return;
            }
            switch (figure)
            {
                case Figures.Triangle:
                    DrawTriangle();
                    break;
                case Figures.Square:
                    DrawSquare();
                    break;
                case Figures.Romb:
                    DrawRomb();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.ReadKey();
        }
    }
}
