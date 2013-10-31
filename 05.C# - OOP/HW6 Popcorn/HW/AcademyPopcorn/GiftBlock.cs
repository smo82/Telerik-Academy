//Task12
//Implement a GiftBlock class. It should be a block, which "drops" a Gift object when it is destroyed. 
//You must NOT edit any existing .cs file. Test the Gift and GiftBlock classes by adding them through the AcademyPopcornMain.cs file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task12
    //------
    class GiftBlock : Block
    {
        public const char Symbol = 'G';

        public GiftBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gifts = new List<GameObject>();

            if (this.IsDestroyed)
            {
                gifts.Add(new Gift(this.topLeft));
            }

            return gifts;
        }
    }
}
