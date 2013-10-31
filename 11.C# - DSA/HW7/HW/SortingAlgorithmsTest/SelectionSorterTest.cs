using System;
using System.Collections.Generic;
using SortingHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAlgorithmsTest
{
    [TestClass]
    public class SelectionSorterTest
    {
        [TestMethod]
        public void SortEmptyTest()
        {
            List<int> testCollection = new List<int>();
            SelectionSorter<int> testSelectionSorter = new SelectionSorter<int>();
            testSelectionSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 0);
        }

        [TestMethod]
        public void SortSingleTest()
        {
            List<int> testCollection = new List<int>() { 1 };
            SelectionSorter<int> testSelectionSorter = new SelectionSorter<int>();
            testSelectionSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 1);
            Assert.AreEqual(testCollection[0], 1);
        }

        [TestMethod]
        public void SortSeveralIntTest()
        {
            List<int> testCollection = new List<int>() { 1, 7, -1, 0, int.MaxValue, int.MinValue };
            SelectionSorter<int> testSelectionSorter = new SelectionSorter<int>();
            testSelectionSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            int[] expectedSortedResult = new[] { int.MinValue, -1, 0, 1, 7, int.MaxValue};
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }

        [TestMethod]
        public void SortAlreadySortedTest()
        {
            List<int> testCollection = new List<int>() { int.MinValue, -1, 0, 1, 7, int.MaxValue };
            SelectionSorter<int> testSelectionSorter = new SelectionSorter<int>();
            testSelectionSorter.Sort(testCollection);

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
            SelectionSorter<int> testSelectionSorter = new SelectionSorter<int>();
            testSelectionSorter.Sort(testCollection);

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
            SelectionSorter<string> testSelectionSorter = new SelectionSorter<string>();
            testSelectionSorter.Sort(testCollection);

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
                new List<double>() {1.5, -18, double.MaxValue, double.MinValue, 0,  -2.5};
            SelectionSorter<double> testSelectionSorter = new SelectionSorter<double>();
            testSelectionSorter.Sort(testCollection);

            Assert.AreEqual(testCollection.Count, 6);

            double[] expectedSortedResult = new[] { double.MinValue, -18, -2.5, 0, 1.5, double.MaxValue };
            for (int i = 0; i < testCollection.Count; i++)
            {
                Assert.AreEqual(testCollection[i], expectedSortedResult[i]);
            }
        }
    }
}
