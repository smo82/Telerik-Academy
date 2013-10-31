//Task05
//Implement a TrailObject class. It should inherit the GameObject class and should have 
//a constructor which takes an additional "lifetime" integer. 
//The TrailObject should disappear after a "lifetime" amount of turns. 
//You must NOT edit any existing .cs file. 
//Then test the TrailObject by adding an instance of it in the engine through the AcademyPopcornMain.cs file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task05
    //------
    class TrailObject : GameObject
    {
        public int Lifetime { get; set; }

        public TrailObject(MatrixCoords topLeft, char[,] body, int pLifetime)
            :base (topLeft, body)
        {
            if (pLifetime < 0)
                throw new ArgumentOutOfRangeException("The lifetime of the object should be a positive number");
            this.Lifetime = pLifetime;
        }

        public override void Update()
        {
            this.Lifetime--;

            if (this.Lifetime == 0)
                this.IsDestroyed = true;
        }
    }
}
