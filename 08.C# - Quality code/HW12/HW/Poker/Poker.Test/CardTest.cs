using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestToStringTwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expect = "2♣";
            string cardString = card.ToString();
            Assert.AreEqual(cardString, expect);
        }

        [TestMethod]
        public void TestToStringTenHearts()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Hearts);
            string expect = "10♥";
            string cardString = card.ToString();
            Assert.AreEqual(cardString, expect);
        }

        [TestMethod]
        public void TestToStringJackDiamonds()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string expect = "J♦";
            string cardString = card.ToString();
            Assert.AreEqual(cardString, expect);
        }

        [TestMethod]
        public void TestToStringAceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expect = "A♠";
            string cardString = card.ToString();
            Assert.AreEqual(cardString, expect);
        }
    }
}
