using System;
using System.Collections.Generic;
using System.Linq;
using SortingHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAlgorithmsTest
{
    [TestClass]
    public class SortableCollectionTest
    {
        [TestMethod]
        public void LinearSearchEmptyTest()
        {
            List<int> testCollection = new List<int>();
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(1);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void LinearSearchSingleTest()
        {
            List<int> testCollection = new List<int>(){ 1 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(1);
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void LinearSearchSingleMissingTest()
        {
            List<int> testCollection = new List<int>() { 2 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(1);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void LinearSearchMultipleItemsTest()
        {
            List<int> testCollection = new List<int>() {9, int.MinValue, 1, 0, int.MaxValue };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(1);
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void LinearSearchMultipleItemsMissingTest()
        {
            List<int> testCollection = new List<int>() { 9, int.MinValue, 1, 0, int.MaxValue };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(8);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void LinearSearchMultipleItemsRepeatingTest()
        {
            List<int> testCollection = new List<int>() { 1, 9, int.MinValue, 1, 0, int.MaxValue, 1 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(1);
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void LinearSearchMultipleItemsRepeatingMissingTest()
        {
            List<int> testCollection = new List<int>() { 1, 9, int.MinValue, 1, 0, int.MaxValue, 1 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch(8);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void LinearSearchStringMultipleItemsTest()
        {
            List<string> testCollection = new List<string>() { "z", "", "a", "abc", "ss", "Z" };
            SortableCollection<string> testSortableColleciton = new SortableCollection<string>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch("abc");
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void LinearSearchStringMultipleItemsMissingTest()
        {
            List<string> testCollection = new List<string>() { "z", "", "a", "abc", "ss", "Z" };
            SortableCollection<string> testSortableColleciton = new SortableCollection<string>(testCollection);

            bool searchResult = testSortableColleciton.LinearSearch("-");
            Assert.IsFalse(searchResult);
        }
        
        [TestMethod]
        public void BinarySearchEmptyTest()
        {
            List<int> testCollection = new List<int>();
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(1);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void BinarySearchSingleTest()
        {
            List<int> testCollection = new List<int>() { 1 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(1);
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void BinarySearchSingleMissingTest()
        {
            List<int> testCollection = new List<int>() { 2 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(1);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void BinarySearchMultipleItemsTest()
        {
            List<int> testCollection = new List<int>() { 9, int.MinValue, 1, 0, int.MaxValue };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(1);
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void BinarySearchMultipleItemsMissingTest()
        {
            List<int> testCollection = new List<int>() { 9, int.MinValue, 1, 0, int.MaxValue };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(8);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void BinarySearchMultipleItemsRepeatingTest()
        {
            List<int> testCollection = new List<int>() { 1, 9, int.MinValue, 1, 0, int.MaxValue, 1 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(1);
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void BinarySearchMultipleItemsRepeatingMissingTest()
        {
            List<int> testCollection = new List<int>() { 1, 9, int.MinValue, 1, 0, int.MaxValue, 1 };
            SortableCollection<int> testSortableColleciton = new SortableCollection<int>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<int>());

            bool searchResult = testSortableColleciton.BinarySearch(8);
            Assert.IsFalse(searchResult);
        }

        [TestMethod]
        public void BinarySearchStringMultipleItemsTest()
        {
            List<string> testCollection = new List<string>() { "z", "", "a", "abc", "ss", "Z" };
            SortableCollection<string> testSortableColleciton =
                new SortableCollection<string>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<string>());

            bool searchResult = testSortableColleciton.BinarySearch("abc");
            Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void BinarySearchStringMultipleItemsMissingTest()
        {
            List<string> testCollection = new List<string>() { "z", "", "a", "abc", "ss", "Z" };
            SortableCollection<string> testSortableColleciton = new SortableCollection<string>(testCollection);
            testSortableColleciton.Sort(new QuickSorter<string>());

            bool searchResult = testSortableColleciton.BinarySearch("-");
            Assert.IsFalse(searchResult);
        }
    }
}
