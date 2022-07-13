using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
            }
        }
        public double Width 
        {
            get => this.width;
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Height 
        {
            get => this.height;
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return (2 * length * width) + (2 * length * height) + (2 * width * height);
        }

        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return (2 * length * height) + (2 * width * height);
        }

        public double Volume()
        {
            //Volume = lwh
            return length * width * height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString();
        }
    }
}
