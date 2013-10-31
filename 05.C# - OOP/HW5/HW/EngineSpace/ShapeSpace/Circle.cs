using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesSpace
{
    public class Circle : Shape
    {
        public Circle(double pWidth)
            : base(pWidth, pWidth)
        { }

        public override double CalculateSurface()
        {
            //I assume that the width of the circle is its diameter
            return Math.PI * Width * Width / 4;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", this.GetType().Name, this.Width);
        }
    }
}