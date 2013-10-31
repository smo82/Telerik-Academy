﻿using System;
using System.Collections.Generic;
using System.Linq;
using SortingHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAlgorithmsTest
{
    [TestClass]
    public class QuickSorterTest
    {
        [TestMethod]
        public void SortEmptyTest()
        {
            List<int> testCollection = new List<int>();
            QuickSorter<int> testQuickSorter = new QuickSorter<int>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 0);
        }

        [TestMethod]
        public void SortSingleTest()
        {
            List<int> testCollection = new List<int>() { 1 };
            QuickSorter<int> testQuickSorter = new QuickSorter<int>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 1);
            Assert.AreEqual(testCollection[0], 1);
        }

        [TestMethod]
        public void SortSeveralIntTest()
        {
            List<int> testCollection = new List<int>() { 1, 7, -1, 0, int.MaxValue, int.MinValue };
            QuickSorter<int> testQuickSorter = new QuickSorter<int>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            int[] expectedSortedResult = new[] { int.MinValue, -1, 0, 1, 7, int.MaxValue };
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }

        [TestMethod]
        public void SortAlreadySortedTest()
        {
            List<int> testCollection = new List<int>() { int.MinValue, -1, 0, 1, 7, int.MaxValue };
            QuickSorter<int> testQuickSorter = new QuickSorter<int>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            int[] expectedSortedResult = new[] { int.MinValue, -1, 0, 1, 7, int.MaxValue };
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }

        [TestMethod]
        public void SortReverseSortedTest()
        {
            List<int> testCollection = new List<int>() { int.MaxValue, 7, 1, 0, -1, int.MinValue };
            QuickSorter<int> testQuickSorter = new QuickSorter<int>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            int[] expectedSortedResult = new[] { int.MinValue, -1, 0, 1, 7, int.MaxValue };
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }

        [TestMethod]
        public void SortStringsTest()
        {
            List<string> testCollection = new List<string>() { "Z", "a", "A", "z", "abv", "abc" };
            QuickSorter<string> testQuickSorter = new QuickSorter<string>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            string[] expectedSortedResult = new[] { "a", "A", "abc", "abv", "z", "Z" };
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }

        [TestMethod]
        public void SortDoubleTest()
        {
            List<double> testCollection =
                new List<double>() { 1.5, -18, double.MaxValue, double.MinValue, 0, -2.5 };
            QuickSorter<double> testQuickSorter = new QuickSorter<double>();
            testQuickSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            double[] expectedSortedResult = new[] { double.MinValue, -18, -2.5, 0, 1.5, double.MaxValue };
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }
    }
}