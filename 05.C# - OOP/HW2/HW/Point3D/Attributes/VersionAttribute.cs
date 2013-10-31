//Task11
//Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and 
//holds a version in the format major.minor (e.g. 2.11). 
//Apply the version attribute to a sample class and display its version at runtime.

using System;

namespace Attributes
{
    //------
    //Task11
    //------
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
     AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        public string Major { get; private set; }
        public string Minor { get; private set; }

        public VersionAttribute (string pMajor, string pMinor)
        {
            this.Major = pMajor;
            this.Minor = pMinor;
        }

        public override string ToString()
        {
                return String.Format("{0}.{1}", this.Major, this.Minor);
        }
    }
}
