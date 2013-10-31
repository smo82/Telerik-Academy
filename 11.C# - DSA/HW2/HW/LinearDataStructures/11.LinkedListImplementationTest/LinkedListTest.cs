using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTest
{
    [TestMethod]
    public void TestLinkedListEnumeratorEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();
        int iterations = 0;
        foreach (int item in testList)
        {
            iterations++;
        }

        Assert.AreEqual(iterations, 0);
    }

    [TestMethod]
    public void TestLinkedListEnumerator()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        testList.Add(4);
        testList.Add(5);

        int[] expectedValues = new int[] { 3, -3, 0, 4, 5 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListAddRepeating()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(3);
        testList.Add(3);

        Assert.AreEqual(testList.Count, 3);

        int[] expectedValues = new int[] { 3, 3, 3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListAddFirst()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(0);
        testList.Add(-3);

        Assert.AreEqual(testList.Count, 3);

        int[] expectedValues = new int[] { 3, 0, -3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }

        testList.AddFirst(-1);

        Assert.AreEqual(testList.Count, 4);

        expectedValues = new int[] { -1, 3, 0, -3 };
        index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListAddLast()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.AddLast(3);
        testList.AddLast(0);
        testList.AddLast(-3);

        Assert.AreEqual(testList.Count, 3);

        int[] expectedValues = new int[] { 3, 0, -3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListAddAfter()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);

        ListItem<int> firstNode = testList.First();
        testList.AddAfter(firstNode, -3);
        testList.AddAfter(firstNode, 0);

        Assert.AreEqual(testList.Count, 3);

        int[] expectedValues = new int[] { 3, 0, -3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListAddBefore()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(-3);

        ListItem<int> firstNode = testList.First();
        testList.AddBefore(firstNode, -1);
        testList.AddBefore(firstNode, 3);
        testList.AddBefore(firstNode, 0);

        Assert.AreEqual(testList.Count, 4);

        int[] expectedValues = new int[] { -1, 3, 0, -3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListClear()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(3);
        testList.Add(3);

        Assert.AreEqual(testList.Count, 3);

        testList.Clear();
        Assert.AreEqual(testList.Count, 0);
    }

    [TestMethod]
    public void TestLinkedListContainsEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();
        bool containsResult = testList.Contains(1);

        Assert.IsFalse(containsResult);
    }

    [TestMethod]
    public void TestLinkedListContainsSingle()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);
        bool containsResult = testList.Contains(1);

        Assert.IsTrue(containsResult);
    }

    [TestMethod]
    public void TestLinkedListContainsMultiple()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(1);
        testList.Add(-3);
        bool containsResult = testList.Contains(1);

        Assert.IsTrue(containsResult);
    }

    [TestMethod]
    public void TestLinkedListContainsMissing()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);
        bool containsResult = testList.Contains(-1);

        Assert.IsFalse(containsResult);
    }

    [TestMethod]
    public void TestLinkedListContainsFirst()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);
        bool containsResult = testList.Contains(3);

        Assert.IsTrue(containsResult);
    }

    [TestMethod]
    public void TestLinkedListContainsLast()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);
        bool containsResult = testList.Contains(-3);

        Assert.IsTrue(containsResult);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestLinkedListCopyToNull()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);

        testList.CopyTo(null, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestLinkedListCopyToFromIncorrectIndex()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);

        int[] testArray = new int[5];
        testList.CopyTo(testArray, 5);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestLinkedListCopyToInsufficientArray()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);

        int[] testArray = new int[2];
        testList.CopyTo(testArray, 0);
    }

    [TestMethod]
    public void TestLinkedListCopyToFull()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);

        int[] testArray = new int[3];
        testList.CopyTo(testArray, 0);

        int[] expectedValues = new int[] { 3, 1, -3 };
        for (int i = 0; i < testArray.Length; i++)
        {
            Assert.AreEqual(testArray[i], expectedValues[i]);
        }
    }

    [TestMethod]
    public void TestLinkedListCopyToNotFull()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(1);
        testList.Add(-3);

        int[] testArray = new int[5];
        testList.CopyTo(testArray, 0);

        int[] expectedValues = new int[] { 3, 1, -3, 0, 0 };
        for (int i = 0; i < testArray.Length; i++)
        {
            Assert.AreEqual(testArray[i], expectedValues[i]);
        }
    }

    [TestMethod]
    public void TestLinkedListCount()
    {
        LinkedList<int> testList = new LinkedList<int>();
        Assert.AreEqual(0, testList.Count);
        testList.Add(3);
        Assert.AreEqual(1, testList.Count);
        testList.Add(-3);
        testList.Add(0);
        Assert.AreEqual(3, testList.Count);
        testList.Remove(0);
        Assert.AreEqual(2, testList.Count);
        testList.Remove(3);
        testList.Remove(-3);
        Assert.AreEqual(0, testList.Count);
    }

    [TestMethod]
    public void TestLinkedListCountRemoveFirst()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        Assert.AreEqual(3, testList.Count);
        testList.Remove(3);
        Assert.AreEqual(2, testList.Count);
    }

    [TestMethod]
    public void TestLinkedListCountRemoveLast()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        Assert.AreEqual(3, testList.Count);
        testList.Remove(0);
        Assert.AreEqual(2, testList.Count);
    }

    [TestMethod]
    public void TestLinkedListRemoveEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();
        bool resultRemove = testList.Remove(0);
        Assert.IsFalse(resultRemove);
    }

    [TestMethod]
    public void TestLinkedListRemoveMissing()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        bool resultRemove = testList.Remove(-2);
        Assert.IsFalse(resultRemove);

        int[] expectedValues = new int[] { 3, -3, 0 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListRemoveFirstItem()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        bool resultRemove = testList.Remove(3);
        Assert.IsTrue(resultRemove);

        int[] expectedValues = new int[] { -3, 0 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListRemoveLastItem()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        bool resultRemove = testList.Remove(0);
        Assert.IsTrue(resultRemove);

        int[] expectedValues = new int[] { 3, -3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListRemoveAll()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);
        bool resultRemove = testList.Remove(-3);
        Assert.IsTrue(resultRemove);

        resultRemove = testList.Remove(3);
        Assert.IsTrue(resultRemove);

        resultRemove = testList.Remove(0);
        Assert.IsTrue(resultRemove);

        Assert.AreEqual(testList.Count, 0);
    }

    [TestMethod]
    public void TestLinkedListRemoveFirst()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);

        bool resultRemove = testList.RemoveFirst();
        Assert.IsTrue(resultRemove);

        int[] expectedValues = new int[] { -3, 0 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListRemoveFirstEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();

        bool resultRemove = testList.RemoveFirst();
        Assert.IsFalse(resultRemove);
    }

    [TestMethod]
    public void TestLinkedListRemoveLast()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);

        bool resultRemove = testList.RemoveLast();
        Assert.IsTrue(resultRemove);

        int[] expectedValues = new int[] { 3, -3 };
        int index = 0;
        foreach (int item in testList)
        {
            Assert.AreEqual(item, expectedValues[index]);
            index++;
        }
    }

    [TestMethod]
    public void TestLinkedListRemoveLastEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();

        bool resultRemove = testList.RemoveLast();
        Assert.IsFalse(resultRemove);
    }

    [TestMethod]
    public void TestLinkedListFirst()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);

        ListItem<int> first = testList.First();
        Assert.AreEqual(first.Value, 3);
    }

    [TestMethod]
    public void TestLinkedListFirstEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();

        ListItem<int> first = testList.First();
        Assert.AreEqual(first, null);
    }

    [TestMethod]
    public void TestLinkedListLast()
    {
        LinkedList<int> testList = new LinkedList<int>();
        testList.Add(3);
        testList.Add(-3);
        testList.Add(0);

        ListItem<int> last = testList.Last();
        Assert.AreEqual(last.Value, 0);
    }

    [TestMethod]
    public void TestLinkedListLastEmpty()
    {
        LinkedList<int> testList = new LinkedList<int>();

        ListItem<int> last = testList.Last();
        Assert.AreEqual(last, null);
    }
}
