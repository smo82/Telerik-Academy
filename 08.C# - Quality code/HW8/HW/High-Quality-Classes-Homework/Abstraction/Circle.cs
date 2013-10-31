using System;

public class Circle : Figure
{
    private double radius;

    /// <summary>
    /// Intializes the new Circle object
    /// </summary>
    /// <param name="radius">The radius of the circle</param>
    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get
        {
            return this.radius;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The circle radius should be bigger then 0!");
            }

            this.radius = value;
        }
    }

    /// <summary>
    /// Calculates the perimeter of the circle
    /// </summary>
    /// <returns>Returns the perimeter of the circle</returns>
    public override double CalcPerimeter()
    {
        double perimeter = 2 * Math.PI * this.Radius;
        return perimeter;
    }

    /// <summary>
    /// Calculates the surface of the circle
    /// </summary>
    /// <returns>Returns the surface of the circle</returns>
    public override double CalcSurface()
    {
        double surface = Math.PI * this.Radius * this.Radius;
        return surface;
    }
}