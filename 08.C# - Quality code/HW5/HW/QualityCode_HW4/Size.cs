using System;

public class Size
{
    private double width;
    private double height;

    public double Width { 
        get
        {
            return width;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The width cannot be a negative number!");
            }
            width = value;
        }
    }
    public double Height { 
        get
        {
            return height;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The height cannot be a negative number!");
            }
            height = value;
        } 
    }

    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }
}
