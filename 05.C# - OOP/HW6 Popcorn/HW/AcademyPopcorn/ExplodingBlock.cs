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
    class ExplodingBlock : Block
    {
        public const char Symbol = '@';

        public ExplodingBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> explosion = new List<GameObject>();

            if (this.IsDestroyed)
            {
                for (int i = this.topLeft.Col - 1; i <= this.topLeft.Col + 1; i++)
                {
                    for (int j = this.topLeft.Row - 1; j <= this.topLeft.Row + 1; j++)
                    {
                        if (!((i == this.topLeft.Col) && (j == this.topLeft.Row)))
                            explosion.Add(new Explosion(new MatrixCoords(j, i), new MatrixCoords(0, 0), 1));
                    }
                }
            }
           
            return explosion;
        }
    }
}
