//Task13
//Implement a shoot ability for the player racket. The ability should only be activated when a Gift object falls on the racket. 
//The shot objects should be a new class (e.g. Bullet) and should destroy normal Block objects 
//(and be destroyed on collision with any block). 
//Use the engine and ShootPlayerRacket method you implemented in task 4, 
//but don't add items in any of the engine lists through the ShootPlayerRacket method. 
//Also don't edit the Racket.cs file. 
//Hint: you should have a ShootingRacket class and override its ProduceObjects method.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task13
    //------
    class ShootingRacket : Racket
    {
        public bool Shoot { get; set; }

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.Shoot = false;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == Racket.CollisionGroupString || otherCollisionGroupString == "ball" || otherCollisionGroupString == "gift";
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> bullets = new List<GameObject>();

            if (this.Shoot == true)
            {
                bullets.Add(new Bullet(this.topLeft));
                bullets.Add(new Bullet(this.topLeft + new MatrixCoords(0, 5)));
                this.Shoot = false;
            }

            return bullets;
        }
    }
}
