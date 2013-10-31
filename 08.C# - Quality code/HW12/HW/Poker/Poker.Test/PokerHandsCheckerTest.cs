using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void TestValidHandOfFive()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidHand = handChecker.IsValidHand(hand);

            Assert.IsTrue(isValidHand);
        }

        [TestMethod]
        public void TestValidHandOfSameCards()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidHand = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValidHand);
        }

        [TestMethod]
        public void TestValidHandOfFour()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidHand = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValidHand);
        }

        [TestMethod]
        public void TestValidHandOfNone()
        {
            List<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidHand = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValidHand);
        }

        [TestMethod]
        public void TestIsStraightFlush()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isStraightFlush = handChecker.IsStraightFlush(hand);

            Assert.IsTrue(isStraightFlush);
        }

        [TestMethod]
        public void TestIsStraightFlushOfNotSequel()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isStraightFlush = handChecker.IsStraightFlush(hand);

            Assert.IsFalse(isStraightFlush);
        }

        [TestMethod]
        public void TestIsStraightFlushOfDifferentSuits()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isStraightFlush = handChecker.IsStraightFlush(hand);

            Assert.IsFalse(isStraightFlush);
        }

        [TestMethod]
        public void TestIsFourOfAKind()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFourOfAKind = handChecker.IsFourOfAKind(hand);

            Assert.IsTrue(isFourOfAKind);
        }

        [TestMethod]
        public void TestIsFourOfAKindOfFullHouse()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFourOfAKind = handChecker.IsFourOfAKind(hand);

            Assert.IsFalse(isFourOfAKind);
        }

        [TestMethod]
        public void TestIsFullHouse()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFullHouse = handChecker.IsFullHouse(hand);

            Assert.IsTrue(isFullHouse);
        }

        [TestMethod]
        public void TestIsFullHouseOfTreeOfAKind()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFullHouse = handChecker.IsFullHouse(hand);

            Assert.IsFalse(isFullHouse);
        }

        [TestMethod]
        public void TestIsFlush()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFlush = handChecker.IsFlush(hand);

            Assert.IsTrue(isFlush);
        }

        [TestMethod]
        public void TestIsFlushWhenStraight()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFlush = handChecker.IsFlush(hand);

            Assert.IsFalse(isFlush);
        }

        [TestMethod]
        public void TestIsFlushFromDifferentSuits()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFlush = handChecker.IsFlush(hand);

            Assert.IsFalse(isFlush);
        }

        [TestMethod]
        public void TestIsStraight()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isStraight = handChecker.IsStraight(hand);

            Assert.IsTrue(isStraight);
        }

        [TestMethod]
        public void TestIsStraightOfNotSequalCards()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isStraight = handChecker.IsStraight(hand);

            Assert.IsFalse(isStraight);
        }

        [TestMethod]
        public void TestIsThreeOfAKind()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isThreeOfAKind = handChecker.IsThreeOfAKind(hand);

            Assert.IsTrue(isThreeOfAKind);
        }

        [TestMethod]
        public void TestIsThreeOfAKindOfFullHouse()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isThreeOfAKind = handChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(isThreeOfAKind);
        }

        [TestMethod]
        public void TestIsTwoPair()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isTwoPair = handChecker.IsTwoPair(hand);

            Assert.IsTrue(isTwoPair);
        }

        [TestMethod]
        public void TestIsTwoPairOfFullHouse()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isTwoPair = handChecker.IsTwoPair(hand);

            Assert.IsFalse(isTwoPair);
        }

        [TestMethod]
        public void TestIsTwoPairOfFourOfAKind()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isTwoPair = handChecker.IsTwoPair(hand);

            Assert.IsFalse(isTwoPair);
        }

        [TestMethod]
        public void TestIsOnePair()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isOnePair = handChecker.IsOnePair(hand);

            Assert.IsTrue(isOnePair);
        }

        [TestMethod]
        public void TestIsOnePairOfTwoPair()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isOnePair = handChecker.IsOnePair(hand);

            Assert.IsFalse(isOnePair);
        }

        [TestMethod]
        public void TestIsOnePairOfFullHouse()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isOnePair = handChecker.IsOnePair(hand);

            Assert.IsFalse(isOnePair);
        }

        [TestMethod]
        public void TestIsOnePairOfFourOfAKind()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Clubs)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isOnePair = handChecker.IsOnePair(hand);

            Assert.IsFalse(isOnePair);
        }

        [TestMethod]
        public void TestHighCard()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsTrue(isHighCard);
        }

        [TestMethod]
        public void TestHighCardOfPair()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void TestHighCardOfTwoPair()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void TestHighCardOfFullHouse()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void TestHighCardOfFourOfAKind()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void TestHighCardOfStraight()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void TestHighCardOfFlush()
        {
            List<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.Seven, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand hand = new Hand(cards);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.IsFalse(isHighCard);
        }

        [TestMethod]
        public void TestCompareHandsHighCardToOnePair()
        {
            List<ICard> cardsFirstPlayer = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Eight, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand handFirstPlayer = new Hand(cardsFirstPlayer);

            List<ICard> cardsSecondPlayer = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Eight, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand handSecondPlayer = new Hand(cardsSecondPlayer);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            int resultCompareHands = handChecker.CompareHands(handFirstPlayer, handSecondPlayer);

            Assert.AreEqual(resultCompareHands, -1);
        }

        [TestMethod]
        public void TestCompareHandsOnePairToTwoPairs()
        {
            List<ICard> cardsFirstPlayer = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand handFirstPlayer = new Hand(cardsFirstPlayer);

            List<ICard> cardsSecondPlayer = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand handSecondPlayer = new Hand(cardsSecondPlayer);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            int resultCompareHands = handChecker.CompareHands(handFirstPlayer, handSecondPlayer);

            Assert.AreEqual(resultCompareHands, -1);
        }

        [TestMethod]
        public void TestCompareHandsOnePairToOnePair()
        {
            List<ICard> cardsFirstPlayer = new List<ICard>()
                {
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand handFirstPlayer = new Hand(cardsFirstPlayer);

            List<ICard> cardsSecondPlayer = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Hearts)
                };
            Hand handSecondPlayer = new Hand(cardsSecondPlayer);
            PokerHandsChecker handChecker = new PokerHandsChecker();
            int resultCompareHands = handChecker.CompareHands(handFirstPlayer, handSecondPlayer);

            Assert.AreEqual(resultCompareHands, 1);
        }
    }
}
