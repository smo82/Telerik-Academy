using System;

namespace Poker
{
    public class Card : ICard, IComparable, IEquatable<ICard>
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var faceStr = GetFaceString();

            var suitSymbol = GetSuitString();

            string result = faceStr + suitSymbol.ToString();
            return result;
        }

        private char GetSuitString()
        {
            char suitSymbol;

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suitSymbol = '♣';
                    break;
                case CardSuit.Diamonds:
                    suitSymbol = '♦';
                    break;
                case CardSuit.Hearts:
                    suitSymbol = '♥';
                    break;
                case CardSuit.Spades:
                    suitSymbol = '♠';
                    break;
                default:
                    throw new InvalidOperationException("Invalid suit: " + this.Suit);
            }
            return suitSymbol;
        }

        private string GetFaceString()
        {
            string faceStr;
            if ((int) this.Face <= 10)
            {
                faceStr = ((int) this.Face).ToString();
            }
            else
            {
                char firstLetterFace = this.Face.ToString()[0];
                faceStr = firstLetterFace.ToString();
            }
            return faceStr;
        }

        public int CompareTo(object obj)
        {
            Card that = obj as Card;
            if (this.Face > that.Face)
            {
                return 1;
            }

            if (this.Face < that.Face)
            {
                return -1;
            }

            if (this.Suit > that.Suit)
            {
                return 1;
            }

            if (this.Suit < that.Suit)
            {
                return -1;
            }

            return 0;
        }

        public bool Equals(Card that)
        {
            if ((this.Face == that.Face) && (this.Suit == that.Suit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(ICard that)
        {
            if ((this.Face == that.Face) && (this.Suit == that.Suit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCardWeight()
        {
            return (int) this.Face*10 + (int) this.Suit;
        }
    }
}
