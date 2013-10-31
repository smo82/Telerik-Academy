using System;

public static class MathUtils
{
    private const double START_COORDINATE_X = 0;
    private const double START_COORDINATE_Y = 0;
    private const double START_COORDINATE_Z = 0;

    /// <summary>
    /// Calculates the volume of a 3D figure
    /// </summary>
    /// <param name="width">The width of the figure</param>
    /// <param name="height">The height of the figure</param>
    /// <param name="depth">The depth of the figure</param>
    /// <returns>Returns the volume of the figure</returns>
    public static double CalcVolume(double width, double height, double depth)
    {
        double volume = width * height * depth;
        return volume;
    }

    /// <summary>
    /// Calculates the distance between to points in the 2D space
    /// </summary>
    /// <param name="x1">The X coordinate of the first point</param>
    /// <param name="y1">The Y coordinate of the first point</param>
    /// <param name="x2">The X coordinate of the second point</param>
    /// <param name="y2">The Y coordinate of the second point</param>
    /// <returns>Returns the distance between the two points in the 2D space</returns>
    public static double CalcDistance2D(double x1, double y1, double x2, double y2)
    {
        double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
        return distance;
    }

    /// <summary>
    /// Calculates the distance between to points in the 3D space
    /// </summary>
    /// <param name="x1">The X coordinate of the first point</param>
    /// <param name="y1">The Y coordinate of the first point</param>
    /// <param name="z1">The Z coordinate of the first point</param>
    /// <param name="x2">The X coordinate of the second point</param>
    /// <param name="y2">The Y coordinate of the second point</param>
    /// <param name="z2">The Z coordinate of the second point</param>
    /// <returns>Returns the distance between the two points in the 3D space</returns>
    public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
        return distance;
    }

    /// <summary>
    /// Calculates the distance between to starting point of the coordinate system and a point in the 3D space
    /// </summary>
    /// <param name="x">The X coordinate of the point</param>
    /// <param name="y">The Y coordinate of the point</param>
    /// <param name="z">The Z coordinate of the point</param>
    /// <returns>Returns the distance between to starting point of the coordinate system and a point in the 3D space</returns>
    public static double CalcDiagonalXYZ(double x, double y, double z)
    {
        double distance = CalcDistance3D(START_COORDINATE_X, START_COORDINATE_Y, START_COORDINATE_Z, x, y, z);
        return distance;
    }

    /// <summary>
    /// Calculates the distance between to starting point of the coordinate system and a point on the Z axis in the 3D space
    /// </summary>
    /// <param name="x">The X coordinate of the point</param>
    /// <param name="y">The Y coordinate of the point</param>
    /// <returns>Returns the distance between to starting point of the coordinate system and a point on the Z axis in the 3D space</returns>
    public static double CalcDiagonalXY(double x, double y)
    {
        double distance = CalcDistance2D(START_COORDINATE_X, START_COORDINATE_Y, x, y);
        return distance;
    }

    /// <summary>
    /// Calculates the distance between to starting point of the coordinate system and a point on the Y axis in the 3D space
    /// </summary>
    /// <param name="x">The X coordinate of the point</param>
    /// <param name="z">The Z coordinate of the point</param>
    /// <returns>Returns the distance between to starting point of the coordinate system and a point on the Y axis in the 3D space</returns>
    public static double CalcDiagonalXZ(double x, double z)
    {
        double distance = CalcDistance2D(START_COORDINATE_X, START_COORDINATE_Z, x, z);
        return distance;
    }

    /// <summary>
    /// Calculates the distance between to starting point of the coordinate system and a point on the X axis in the 3D space
    /// </summary>
    /// <param name="y">The Y coordinate of the point</param>
    /// <param name="z">The Z coordinate of the point</param>
    /// <returns>Returns the distance between to starting point of the coordinate system and a point on the X axis in the 3D space</returns>
    public static double CalcDiagonalYZ(double y, double z)
    {
        double distance = CalcDistance2D(START_COORDINATE_Y, START_COORDINATE_Z, y, z);
        return distance;
    }
}