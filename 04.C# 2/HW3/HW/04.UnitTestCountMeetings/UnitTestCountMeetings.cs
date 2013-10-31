using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04.UnitTestCountMeetings
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestCountMeetings
    {
        [TestMethod]
        public void TestCountMeetings1()
        {
            int [] elementsList = new [] {1,2,3,4,5};
            int count = CountMeetings.CountNumberMeetings(2, elementsList);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TestCountMeetings2()
        {
            int[] elementsList = new int[0];
            int count = CountMeetings.CountNumberMeetings(2, elementsList);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void TestCountMeetings3()
        {
            int[] elementsList = new[] { 1, 2, 3, 4, 5 };
            int count = CountMeetings.CountNumberMeetings(0, elementsList);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void TestCountMeetings4()
        {
            int[] elementsList = new[] { 1, 2, 1, 4, 1 };
            int count = CountMeetings.CountNumberMeetings(1, elementsList);
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestCountMeetings5()
        {
            int[] elementsList = new[] { -1, 2, -1, 4, 1 };
            int count = CountMeetings.CountNumberMeetings(-1, elementsList);
            Assert.AreEqual(2, count);
        }
    }
}
