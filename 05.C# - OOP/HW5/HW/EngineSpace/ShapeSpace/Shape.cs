using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesSpace
{
    public abstract class Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Shape(double pWidth, double pHeight)
        {
            this.Width = pWidth;
            this.Height = pHeight;
        }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return String.Format("{0} ({1}, {2})", this.GetType().Name, this.Width, this.Height);
        }
    }
}