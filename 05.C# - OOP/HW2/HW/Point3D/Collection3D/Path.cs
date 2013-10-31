//Task04
//Create a class Path to hold a sequence of points in the 3D space. 
//Create a static class PathStorage with static methods to save and load paths from a text file. 
//Use a file format of your choice.

using System;
using System.Collections.Generic;
using Attributes;

namespace Collection3D
{
    //------
    //Task04
    //------
    [Version("00", "05")]
    public class Path
    {
        private List<Point3D> path;
        public int Count { get; set; }

        //Constructor1
        public Path ()
        {
            this.path = new List<Point3D>();
            this.Count = 0;
        }

        //Constructor2
        public Path (int [,] pathArr):this()
        {
            AddPath(pathArr);
        }

        public void AddPoint(int X, int Y, int Z)
        {
            this.path.Add(new Point3D(X, Y, Z));
            this.Count++;
        }

        public void AddPath (int [,] pathArr)
        {
            for (int i = 0; i < pathArr.GetLength(0); i++)
            {
                AddPoint(pathArr[i, 0], pathArr[i, 1], pathArr[i, 2]);
            }
        }

        [Version("01", "05")]
        public Point3D [] GetPath ()
        {
            return this.path.ToArray ();
        }
    }
}
