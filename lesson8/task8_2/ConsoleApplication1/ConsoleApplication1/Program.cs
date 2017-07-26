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
            var carConstructor =new CarConstructor();
            Console.WriteLine("Enter transmission number:");
            var transmissionnumber = Convert.ToInt32(Console.ReadLine());
            var transmission = new Transmission((TransmissionTypes)transmissionnumber);
            Console.WriteLine("Enter color number:");
            var colornumber = Convert.ToInt32(Console.ReadLine());
            var color = new Color((ColorTypes)colornumber);
            Console.WriteLine("Enter engine number:");
            var enginenumber = Convert.ToInt32(Console.ReadLine());
            var engine = new Engine((EngineTypes)enginenumber);
            var car = carConstructor.Constructor(engine,color,transmission);
            car.PrintDetails();
            carConstructor.Reconstruct(car);
            car.PrintDetails();
            Console.ReadKey();
        }
    }
}
