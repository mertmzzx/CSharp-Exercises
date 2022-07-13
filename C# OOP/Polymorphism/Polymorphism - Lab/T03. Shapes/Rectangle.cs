using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return (2 * this.height) + (2 * this.width);
        }

        public override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";
        }
    }
}
