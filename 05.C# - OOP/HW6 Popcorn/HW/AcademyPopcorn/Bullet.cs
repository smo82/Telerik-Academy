using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '.' } }, new MatrixCoords(-1, 0))
        {}

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "unpassableBlock";            
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }
    }
}
