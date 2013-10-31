//Task10
//Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. 
//You must NOT edit any existing .cs file. Hint: what does an explosion "produce"?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task10
    //------
    class Explosion : Ball
    {
        public const char Symbol = '*';

        public int Lifetime { get; set; }

        public Explosion(MatrixCoords topLeft, MatrixCoords speed, int pLifetime)
            : base(topLeft, speed)
        {
            this.body[0, 0] = Explosion.Symbol;
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
