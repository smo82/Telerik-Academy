//Task11
//Implement a Gift class. It should be a moving object, which always falls down. 
//The gift shouldn't collide with any ball, but should collide (and be destroyed) with the racket. 
//You must NOT edit any existing .cs file. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task11
    //------
    class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '?' } }, new MatrixCoords(1, 0))
        {}

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.IndexOf("racket") >= 0)
                this.IsDestroyed = true;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> newRacket = new List<GameObject>();
            if (this.IsDestroyed)
            {
                newRacket.Add(new ShootingRacket(this.topLeft + new MatrixCoords(1, 0), AcademyPopcornMain.RacketLength));
            }                

            return newRacket;
        }
    }
}
