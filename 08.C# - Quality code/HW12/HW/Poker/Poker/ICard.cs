using System;

namespace Poker
{
    public interface ICard : IEquatable<Card>
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        bool Equals(ICard that);
        string ToString();

        int GetCardWeight();
    }
}
