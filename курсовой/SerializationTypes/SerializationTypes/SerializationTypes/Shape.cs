using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTypes
{
    [Serializable]
    public abstract class Shape
    {
        public double Size { get; set; }

        public string Color { get; set; }

        protected Shape(double size, string color)
        {
            Size = size;
            Color = color;
        }
    }
}
