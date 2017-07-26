using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum ColorTypes
    {
        Blue,
        Green,
    }
    class Color
    {
        public Color(ColorTypes colortype)
        {
            ColorType = colortype;
        }

        public ColorTypes ColorType { get; set; }
    }
}
