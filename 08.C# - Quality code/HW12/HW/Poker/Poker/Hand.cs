using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("The list of cards should not be null");
            }

            this.Cards = cards;
        }

        public override string ToString()
        {
            ICard[] cardsAsArray = new ICard[this.Cards.Count];

            this.Cards.CopyTo(cardsAsArray, 0);

            string result = string.Join<ICard>(" ", cardsAsArray);
            return result;
        }
    }
}
