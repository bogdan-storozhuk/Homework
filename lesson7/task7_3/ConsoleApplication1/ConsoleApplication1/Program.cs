using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    struct Point
    {
        private int _x, _y;
        public Point(int x,int y)
        {
            _x = x;
            _y = y;
        }
    }
    class ShapeDescriptor
    {
        private string shapeType;
        public ShapeDescriptor(Point p1, Point p2,Point p3)
        {
            shapeType = "Triangle";
        }

        public ShapeDescriptor(Point p1, Point p2, Point p3, Point p4)
        {
            shapeType = "Square";
        }

        public ShapeDescriptor(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            shapeType = "Pentagon";
        }

        public string ShapeType { get { return shapeType; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var shape = new ShapeDescriptor(new Point(1,3), new Point(3,4), new Point(3,4) );
            Console.WriteLine(shape.ShapeType);
            Console.ReadKey();
        }
    }
}
