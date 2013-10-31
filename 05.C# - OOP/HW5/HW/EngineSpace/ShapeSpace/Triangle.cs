using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesSpace
{
    public class Triangle : Shape
    {
        public Triangle(double pWidth, double pHeight)
            : base(pWidth, pHeight)
        { }

        public override double CalculateSurface()
        {
            return Height * Width / 2;
        }
    }
}