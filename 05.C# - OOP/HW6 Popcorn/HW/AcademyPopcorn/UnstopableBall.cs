//Task08
//Implement an UnstoppableBall and an UnpassableBlock. 
//The UnstopableBall only bounces off UnpassableBlocks and will destroy any other block it passes through. 
//The UnpassableBlock should be indestructible. 
//Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method and the CollisionData class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task08
    //------
    class UnstopableBall : Ball
    {
        //public new const string CollisionGroupString = "unstopableBall";

        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {}

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "unpassableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.IndexOf("unpassableBlock") >= 0 ||
                collisionData.hitObjectsCollisionGroupStrings.IndexOf("racket") >= 0)
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
