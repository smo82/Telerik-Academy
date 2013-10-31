using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Test
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandWithNullCardsCreation()
        {
            Hand hand = new Hand(null);
        }

        [TestMethod]
        public void TestOneCardHandToString()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            Hand hand = new Hand(new List<ICard>(){card});

            string handToString = hand.ToString();
            string expect = "A♣";

            Assert.AreEqual(handToString, expect);
        }

        [TestMethod]
        public void TestFiveCardHandToString()
        {
            Card card1 = new Card(CardFace.Queen, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Seven, CardSuit.Hearts);
            Card card3 = new Card(CardFace.Two, CardSuit.Spades);
            Card card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Ten, CardSuit.Diamonds);

            Hand hand = new Hand(new List<ICard>() { card1, card2, card3, card4, card5 });

            string handToString = hand.ToString();
            string expect = "Q♣ 7♥ 2♠ J♦ 10♦";

            Assert.AreEqual(handToString, expect);
        }

        [TestMethod]
        public void TestEmptyHandToString()
        {
            Hand hand = new Hand(new List<ICard>() { });

            string handToString = hand.ToString();
            string expect = "";

            Assert.AreEqual(handToString, expect);
        }
    }
}
