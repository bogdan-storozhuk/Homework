using System;
using System.Windows.Media;

namespace WpfChatClient.SerializationTypes
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