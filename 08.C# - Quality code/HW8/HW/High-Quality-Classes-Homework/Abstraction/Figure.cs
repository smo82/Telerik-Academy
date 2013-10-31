using System;

public abstract class Figure
{
    /// <summary>
    /// Calculates the perimeter of the figure
    /// </summary>
    /// <returns>Returns the perimeter of the figure</returns>
    public abstract double CalcPerimeter();

    /// <summary>
    /// Calculates the surface of the figure
    /// </summary>
    /// <returns>Returns the surface of the figure</returns>
    public abstract double CalcSurface();
}