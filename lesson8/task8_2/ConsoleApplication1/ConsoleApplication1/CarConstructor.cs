using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CarConstructor
    {
        public Car Constructor(Engine engine, Color color, Transmission transmission)
        {
            return new Car(engine, color, transmission);
        }

        public Car Reconstruct(Car car)
        {
            Console.WriteLine("Enter engine number:");
            var enginenumber = Convert.ToInt32(Console.ReadLine());
            car.EngineType = (EngineTypes) enginenumber;
            return car;
        }
    }
}
