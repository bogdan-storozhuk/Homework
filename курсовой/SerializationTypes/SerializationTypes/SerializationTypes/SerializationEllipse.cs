using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTypes
{
    [Serializable]
    public class SerializationEllipse:Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }

        public SerializationEllipse(double size, string color, double width, double height, double left, double top)
            : base(size, color)
        {
            Width = width;
            Height = height;
            Left = left;
            Top = top;
        }
    }
}
