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
    public class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "unpassableBlock";

        public const char Symbol = '=';

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }
    }
}
