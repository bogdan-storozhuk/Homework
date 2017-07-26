using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Car
    {
        private EngineTypes _engineType;
        private ColorTypes _colorType;
        private TransmissionTypes _transmissionType;

        public Car(Engine engine, Color color, Transmission transmission)
        {
            _engineType = engine.Enginetype;
            _colorType = color.ColorType;
            _transmissionType = transmission.TransmissionType;
        }

        public EngineTypes EngineType
        {
            get { return _engineType; }
            set { _engineType = value; }
        }

        public void PrintDetails()
        {
            Console.WriteLine(_engineType);
            Console.WriteLine(_colorType);
            Console.WriteLine(_transmissionType);
        }
    }
}
