using System;
using System.Windows.Media;

namespace WpfChatClient.SerializationTypes
{
    [Serializable]
    public class SerializationLine : Shape
    {
        public double StartPositionX { get; set; }
        public double StartPositionY { get; set; }
        public double EndPositionX { get; set; }
        public double EndPositionY { get; set; }

        public SerializationLine(double startPositionX, double startPositionY, double endPositionX, double endPositionY,double size, string color) : base(size, color)
        {
            StartPositionX = startPositionX;
            StartPositionY = startPositionY;
            EndPositionX = endPositionX;
            EndPositionY = endPositionY;
        }

    }
}