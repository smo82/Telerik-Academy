using System;

public class Rectangle : Figure
{
    private double width;
    private double height;

    /// <summary>
    /// Intializes the new Rectangle object
    /// </summary>
    /// <param name="width">The width of the rectangle</param>
    /// <param name="height">The height of the rectangle</param>
    public Rectangle(double width, double height)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Width 
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The rectangle width should be bigger then 0!");
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

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The rectangle height should be bigger then 0!");
            }

            this.height = value;
        }
    }

    /// <summary>
    /// Calculates the perimeter of the rectangle
    /// </summary>
    /// <returns>Returns the perimeter of the rectangle</returns>
    public override double CalcPerimeter()
    {
        double perimeter = 2 * (this.Width + this.Height);
        return perimeter;
    }

    /// <summary>
    /// Calculates the surface of the rectangle
    /// </summary>
    /// <returns>Returns the surface of the rectangle</returns>
    public override double CalcSurface()
    {
        double surface = this.Width * this.Height;
        return surface;
    }
}