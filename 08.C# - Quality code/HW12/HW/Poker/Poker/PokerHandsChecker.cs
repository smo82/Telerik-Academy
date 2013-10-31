using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            IList<ICard> handCards = hand.Cards;

            if (handCards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < handCards.Count - 1; i++)
            {
                for (int j = i + 1; j < handCards.Count; j++)
                {
                    if (handCards[i].Equals(handCards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (!IsStraight(hand))
            {
                return false;
            }

            if (!HasSameSuits(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            IList<ICard> handCards = hand.Cards;

            var handCardsByFacesCount = HandCardsByFacesCount(handCards);

            for (int i = 0; i < handCardsByFacesCount.Length; i++)
            {
                if (handCardsByFacesCount[i] == 4)
                {
                    return true;
                }
            }
            
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            IList<ICard> handCards = hand.Cards;

            var handCardsByFacesCount = HandCardsByFacesCount(handCards);

            bool hasPair = false;
            bool hasTreeOfAKind = false;

            for (int i = 0; i < handCardsByFacesCount.Length; i++)
            {
                if (handCardsByFacesCount[i] == 3)
                {
                    hasTreeOfAKind = true;
                }

                if (handCardsByFacesCount[i] == 2)
                {
                    hasPair = true;
                }
            }

            bool isFullHouse = hasPair && hasTreeOfAKind;
            return isFullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsStraight(hand))
            {
                return false;
            }

            if (!HasSameSuits(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            
            IList<ICard> handCards = hand.Cards;
            ICard[] handCardsArray = new ICard[handCards.Count];
            handCards.CopyTo(handCardsArray, 0);

            IEnumerable<ICard> handCardsSorted = handCardsArray.OrderBy(card => (int) card.Face);
            ICard[] handCardsSortedArray = handCardsSorted.ToArray();

            for (int i = 0; i < handCardsSortedArray.Length - 1; i++)
            {
                int currentCardFaceAsInt = (int) handCardsSortedArray[i].Face;
                int nextCardFaceAsInt = (int) handCardsSortedArray[i + 1].Face;
                if ((currentCardFaceAsInt + 1) != nextCardFaceAsInt)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            IList<ICard> handCards = hand.Cards;

            var handCardsByFacesCount = HandCardsByFacesCount(handCards);

            bool hasPair = false;
            bool hasTreeOfAKind = false;

            for (int i = 0; i < handCardsByFacesCount.Length; i++)
            {
                if (handCardsByFacesCount[i] == 3)
                {
                    hasTreeOfAKind = true;
                }

                if (handCardsByFacesCount[i] == 2)
                {
                    hasPair = true;
                    break;
                }
            }

            bool isThreeOfAKind = hasTreeOfAKind && !hasPair;

            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            IList<ICard> handCards = hand.Cards;

            var handCardsByFacesCount = HandCardsByFacesCount(handCards);

            int pairCount = 0;

            for (int i = 0; i < handCardsByFacesCount.Length; i++)
            {
                if (handCardsByFacesCount[i] == 2)
                {
                    pairCount++;
                }
            }

            bool isTwoPair = pairCount == 2;

            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            IList<ICard> handCards = hand.Cards;

            var handCardsByFacesCount = HandCardsByFacesCount(handCards);

            bool hasTreeOfAKind = false;
            int pairCount = 0;

            for (int i = 0; i < handCardsByFacesCount.Length; i++)
            {
                if (handCardsByFacesCount[i] == 3)
                {
                    hasTreeOfAKind = true;
                    break;
                }

                if (handCardsByFacesCount[i] == 2)
                {
                    pairCount++;
                }
            }

            bool isOnePair = (pairCount == 1) && !hasTreeOfAKind;

            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsStraight(hand))
            {
                return false;
            }

            if (IsFlush(hand))
            {
                return false;
            }

            IList<ICard> handCards = hand.Cards;

            var handCardsByFacesCount = HandCardsByFacesCount(handCards);

            bool isHighCard = true;

            for (int i = 0; i < handCardsByFacesCount.Length; i++)
            {
                if (handCardsByFacesCount[i] > 1)
                {
                    isHighCard = false;
                    break;
                }
            }

            return isHighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            HandType firstHandType = GetHandType(firstHand);
            HandType secondHandType = GetHandType(secondHand);

            if (firstHandType > secondHandType)
            {
                return 1;
            }

            if (firstHandType < secondHandType)
            {
                return -1;
            }

            switch (firstHandType)
            {
                case HandType.HighCard:
                    return CompareHighCardHands(firstHand, secondHand);
                case HandType.OnePair:
                    return CompareOnePairHands(firstHand, secondHand);
                case HandType.TwoPair:
                    break;
                case HandType.ThreeOfAKind:
                    break;
                case HandType.Straight:
                    break;
                case HandType.Flush:
                    break;
                case HandType.FullHouse:
                    break;
                case HandType.FourOfAKind:
                    break;
                case HandType.StraightFlush:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return 0;
        }

        private int CompareOnePairHands(IHand firstHand, IHand secondHand)
        {
            int comparePair = ComparePair(firstHand, secondHand);

            if (comparePair == 0)
            {
                ICard[] firstHandHighCards = GetHandHighCards(firstHand, 2);
                ICard[] secondHandHighCards = GetHandHighCards(secondHand, 2);
                return CompareHighCardLists(firstHandHighCards, secondHandHighCards);
            }
            else if (comparePair > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private ICard[] GetHandHighCards(IHand hand, int countNumber)
        {
            IList<ICard> cards = hand.Cards;

            int[] cardsFaceCount = HandCardsByFacesCount(cards);

            List<int> highCardsIndexes = new List<int>();

            for (int i = 0; i < cardsFaceCount.Length; i++)
            {
                if ((cardsFaceCount[i] != countNumber) && (cardsFaceCount[i] > 0))
                {
                    highCardsIndexes.Add(i);
                }
            }

            ICard[] highCards = new ICard[highCardsIndexes.Count];
            int highCardIndex = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                int cardIndex = (int) cards[i].Face;
                if (highCardsIndexes.Contains(cardIndex))
                {
                    highCards[highCardIndex] = cards[i];
                    highCardIndex++;
                }
            }

            return highCards;
        }

        private int CompareHighCardHands(IHand firstHand, IHand secondHand)
        {
            return CompareHighCardLists(firstHand.Cards, secondHand.Cards);
        }

        private int CompareHighCardLists(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            int firstHandHighCardWeight = GetHighCardWeight(firstHandCards);
            int secondHandHighCardWeight = GetHighCardWeight(secondHandCards);

            return firstHandHighCardWeight - secondHandHighCardWeight;
        }

        private int ComparePair(IHand firstHand, IHand secondHand)
        {
            int[] firstHandPairFace = GetCardsWithGivenFaceByCount(firstHand.Cards, 2);
            int[] secondHandPairFace = GetCardsWithGivenFaceByCount(secondHand.Cards, 2);

            return firstHandPairFace[0] - secondHandPairFace[0];
        }

        private int[] GetCardsWithGivenFaceByCount(IList<ICard> cards, int countNumber)
        {
            int[] cardsFaceCount = HandCardsByFacesCount(cards);

            List<int> cardsWithFaceByCount = new List<int>();

            for (int i = 0; i < cardsFaceCount.Length; i++)
            {
                if (cardsFaceCount[i] == countNumber)
                {
                    cardsWithFaceByCount.Add(i);
                }
            }

            return cardsWithFaceByCount.ToArray();
        }

        private int GetHighCardWeight(IList<ICard> handCards)
        {
            int highCardWeight = handCards[0].GetCardWeight();

            for (int i = 1; i < handCards.Count; i++)
            {
                int currentCardWeight = handCards[i].GetCardWeight();

                if (currentCardWeight > highCardWeight)
                {
                    highCardWeight = currentCardWeight;
                }
            }

            return highCardWeight;
        }

        private HandType GetHandType(IHand hand)
        {
            if (IsStraightFlush(hand))
            {
                return HandType.StraightFlush;
            }

            if (IsFourOfAKind(hand))
            {
                return HandType.FourOfAKind;
            }

            if (IsFullHouse(hand))
            {
                return HandType.FullHouse;
            }

            if (IsFlush(hand))
            {
                return HandType.Flush;
            }

            if (IsStraight(hand))
            {
                return HandType.Straight;
            }

            if (IsThreeOfAKind(hand))
            {
                return HandType.ThreeOfAKind;
            }

            if (IsTwoPair(hand))
            {
                return HandType.TwoPair;
            }

            if (IsOnePair(hand))
            {
                return HandType.OnePair;
            }

            if (IsHighCard(hand))
            {
                return HandType.HighCard;
            }

            throw new ArgumentOutOfRangeException("Invalid hand");
        }

        private static int[] HandCardsByFacesCount(IList<ICard> handCards)
        {
            int[] handCardsByFacesCount = new int[(int)CardFace.Ace + 1];

            for (int i = 0; i < handCards.Count; i++)
            {
                int handCardsFaceInt = (int)handCards[i].Face;
                handCardsByFacesCount[handCardsFaceInt]++;
            }
            return handCardsByFacesCount;
        }

        private static bool HasSameSuits(IHand hand)
        {
            IList<ICard> handCards = hand.Cards;

            CardSuit firstCardSuit = handCards[0].Suit;

            for (int i = 1; i < handCards.Count; i++)
            {
                if (firstCardSuit != handCards[i].Suit)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
