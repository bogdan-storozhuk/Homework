using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
      public static int RandomNumber;
      public static string Number;

        public static bool GuessNumber()
        {
            Console.WriteLine("Enter random number(1-10):");
             Number = Console.ReadLine();
            if (!Regex.IsMatch(Number, "^[0-9]*$"))
            {
                throw new Exception("wrong input");
            }
            Random random = new Random();
            RandomNumber = random.Next(1, 10);
            if (Convert.ToInt32(Number)==RandomNumber)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            bool matched = false;
            while (!matched)
            {

                try
                {
                    matched = GuessNumber();
                    Console.WriteLine("Generated number:{0}", RandomNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            Console.WriteLine("Success:{0}={1}",RandomNumber,Number);
            Console.ReadKey();
        }
    }
}
