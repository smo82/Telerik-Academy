using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ListMethodsTest
{
    [TestMethod]
    public void TestGetLongestSubsequenceEmpty()
    {
        List<int> numbers = new List<int>();
        List<int> resultList = ListMethods.GetLongestSubsequence(numbers);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestGetLongestSubsequenceNull()
    {
        List<int> resultList = ListMethods.GetLongestSubsequence(null);
    }

    [TestMethod]
    public void TestGetLongestSubsequenceSingle()
    {
        List<int> numbers = new List<int>() { 1 };
        List<int> resultList = ListMethods.GetLongestSubsequence(numbers);

        List<int> expectedResult = new List<int>() { 1 };
        for (int i = 0; i < resultList.Count; i++)
        {
            Assert.AreEqual(resultList[i], expectedResult[i]);
        }
    }

    [TestMethod]
    public void TestGetLongestSubsequenceSingleSequence()
    {
        List<int> numbers = new List<int>() { 1, 1, 1 };
        List<int> resultList = ListMethods.GetLongestSubsequence(numbers);
        
        List<int> expectedResult = new List<int>() { 1, 1, 1 };
        for (int i = 0; i < resultList.Count; i++)
        {
            Assert.AreEqual(resultList[i], expectedResult[i]);
        }
    }

    [TestMethod]
    public void TestGetLongestSubsequenceLastSequence()
    {
        List<int> numbers = new List<int>() { 1, 1, 1, 2, 3, 6, 6, 9, 9, 9, 9 };
        List<int> resultList = ListMethods.GetLongestSubsequence(numbers);

        List<int> expectedResult = new List<int>() { 9, 9, 9, 9 };
        for (int i = 0; i < resultList.Count; i++)
        {
            Assert.AreEqual(resultList[i], expectedResult[i]);
        }
    }

    [TestMethod]
    public void TestGetLongestSubsequenceSequenceInMiddle()
    {
        List<int> numbers = new List<int>() { 1, 1, 1, 2, 3, -6, -6, -6, -6, 9, 9 };
        List<int> resultList = ListMethods.GetLongestSubsequence(numbers);

        List<int> expectedResult = new List<int>() { -6, -6, -6, -6 };
        for (int i = 0; i < resultList.Count; i++)
        {
            Assert.AreEqual(resultList[i], expectedResult[i]);
        }
    }
}