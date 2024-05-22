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
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");

                }
                this.height = value;
            }
        }
        
        public string GetVolume()
        {
            return $"Volume - {length * width * height:F2}";
        }
        public string GetLateralSurfaceArea()
        {
            return $"Lateral Surface Area - {(2*length*height) + (2*width*height):F2}";
        }
        public string GetSurfaceArea()
        {
            return $"Surface Area - {(2*length*width)+(2 * length * height) + (2 * width * height):F2}";
        }

    }
}
