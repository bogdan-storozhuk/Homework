using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum Color
    {
        Blue,
        Red, 
        Yellow,
        Green
    }

    enum Model
    {
        BMV,
        Zaporozhez,
        Lamborgini,
        Tayota,
        Mitsubishi
    }
    class Car
    {
        public Model Model { get; set; }

        public string Year { get; set; }

        public Color Color { get; set; }
    }

    static class TuningAtelier
    {
       public static void TuneCar(Car car)
       {
           car.Color = Color.Red;
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            Console.WriteLine("Enter num car model:");
            int numberOFModel = int.Parse(Console.ReadLine());
            car.Color = (Color) numberOFModel;
            Console.WriteLine("Enter release date:");
            car.Year = Console.ReadLine();
            Console.WriteLine("Enter car color:");
            car.Color = (Color)int.Parse(Console.ReadLine());
            Console.WriteLine(" Before tuning:");
            Console.WriteLine("Car model:{0}", car.Model);
            Console.WriteLine("Release date:{0}", car.Year);
            Console.WriteLine("Car color:{0}", car.Color);
            Console.WriteLine("Press Enter");
            Console.ReadKey();
            TuningAtelier.TuneCar(car);
            Console.WriteLine("After tuning:");
            Console.WriteLine("Car model:{0}",car.Model);
            Console.WriteLine("Release date:{0}",car.Year);
            Console.WriteLine("Car color:{0}",car.Color);
            Console.ReadKey();
        }
    }
}
