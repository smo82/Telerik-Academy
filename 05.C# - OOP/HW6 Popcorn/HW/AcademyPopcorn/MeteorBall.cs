//Task06
//Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of TrailObject objects. 
//Each trail objects should last for 3 "turns". Other than that, the Meteorite ball should behave the same way as the normal ball. 
//You must NOT edit any existing .cs file.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task06
    //------
    class MeteorBall : Ball
    {
        public MeteorBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {}

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject> () {new TrailObject(this.topLeft, new char[,] { { '*' } }, 3)};
        }
    }
}
