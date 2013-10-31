//Task03
//Write a static class with a static method to calculate the distance between two points in the 3D space.

using System;

namespace Collection3D
{
    public static class Calc3D
    {
        //------
        //Task03
        //------
        public static double Distance(Point3D firstPoint, Point3D secondPoint)
        {
            return Math.Sqrt((firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X) +
                             (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y) +
                             (firstPoint.Z - secondPoint.Z) * (firstPoint.Z - secondPoint.Z));
        }
    }
}
