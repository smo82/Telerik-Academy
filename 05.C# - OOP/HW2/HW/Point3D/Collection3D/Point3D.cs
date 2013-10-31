//Task01
//Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
//Implement the ToString() to enable printing a 3D point.

//Task02
//Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
//Add a static property to return the point O.

//Task11
//Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and 
//holds a version in the format major.minor (e.g. 2.11). 
//Apply the version attribute to a sample class and display its version at runtime.

using System;
using Attributes;
using System.Reflection;

namespace Collection3D
{
    //------
    //Task01
    //------
    [Version("01", "00")]
    [Version("01", "01")]
    public struct Point3D
    {        
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        //Constructor
        public Point3D (int pX, int pY, int pZ):this()
        {
            this.X = pX;
            this.Y = pY;
            this.Z = pZ;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
        }

        //------
        //Task02
        //------
        static private readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        public static Point3D ZeroPoint
        {
            get
            {
                return zeroPoint;
            }
            set {;}
        }

        //------
        //Task11
        //------
        public static void Main() 
        {
            //Struct Attributes
            Type testType = typeof(Point3D);
            object[] testAttributes = testType.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in testAttributes)
            {
                Console.WriteLine("Struct version: {0}", attribute);
            }

            //Class Attributes
            testType = typeof(Path);
            testAttributes = testType.GetCustomAttributes(false);
            Console.WriteLine(new String ('*', 20));
            foreach (VersionAttribute attribute in testAttributes)
            {
                Console.WriteLine("Class version: {0}", attribute);
            }

            //Method Attributes
            MethodInfo[] methods = testType.GetMethods();

            foreach (MethodInfo method in methods)
            {
                testAttributes = method.GetCustomAttributes(false);
                if (testAttributes.Length > 0)
                {
                    foreach (object attribute in testAttributes)
                    {
                        if (attribute is VersionAttribute)
                        {
                            Console.WriteLine(new String('*', 20));
                            Console.WriteLine("Method {0} version: {1}", method, attribute);
                        }   
                    }
                }
            }
        }
    }
}
