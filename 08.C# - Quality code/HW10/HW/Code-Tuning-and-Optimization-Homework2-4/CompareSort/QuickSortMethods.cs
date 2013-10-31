using System;
using System.Collections.Generic;

public class QuickSortMethods
{
    public static List<T> SortGeneric<T>(List<T> listIn) where T : IComparable
    {
        List<T> sortedList = new List<T>();
        sortedList.AddRange(listIn);

        var listCount = sortedList.Count;

        if (listCount <= 1)
        {
            return sortedList;
        }
        else
        {
            int pivotIndex = listCount / 2;
            T pivotElement = sortedList[pivotIndex];

            List<T> subListLeft = new List<T>();
            List<T> subListRight = new List<T>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            for (int i = pivotIndex + 1; i < listCount; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            subListLeft = SortGeneric(subListLeft);
            subListRight = SortGeneric(subListRight);

            List<T> resultList = new List<T>();
            resultList.AddRange(subListLeft);
            resultList.Add(pivotElement);
            resultList.AddRange(subListRight);

            return resultList;
        }
    }

    public static List<int> SortInt(List<int> listIn)
    {
        List<int> sortedList = new List<int>();
        sortedList.AddRange(listIn);

        var listCount = sortedList.Count;

        if (listCount <= 1)
        {
            return sortedList;
        }
        else
        {
            int pivotIndex = listCount / 2;
            int pivotElement = sortedList[pivotIndex];

            List<int> subListLeft = new List<int>();
            List<int> subListRight = new List<int>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            for (int i = pivotIndex + 1; i < listCount; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            subListLeft = SortGeneric(subListLeft);
            subListRight = SortGeneric(subListRight);

            List<int> resultList = new List<int>();
            resultList.AddRange(subListLeft);
            resultList.Add(pivotElement);
            resultList.AddRange(subListRight);

            return resultList;
        }
    }

    public static List<double> SortDouble(List<double> listIn)
    {
        List<double> sortedList = new List<double>();
        sortedList.AddRange(listIn);

        var listCount = sortedList.Count;

        if (listCount <= 1)
        {
            return sortedList;
        }
        else
        {
            int pivotIndex = listCount / 2;
            double pivotElement = sortedList[pivotIndex];

            List<double> subListLeft = new List<double>();
            List<double> subListRight = new List<double>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            for (int i = pivotIndex + 1; i < listCount; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            subListLeft = SortGeneric(subListLeft);
            subListRight = SortGeneric(subListRight);

            List<double> resultList = new List<double>();
            resultList.AddRange(subListLeft);
            resultList.Add(pivotElement);
            resultList.AddRange(subListRight);

            return resultList;
        }
    }

    public static List<string> SortString(List<string> listIn)
    {
        List<string> sortedList = new List<string>();
        sortedList.AddRange(listIn);

        var listCount = sortedList.Count;

        if (listCount <= 1)
        {
            return sortedList;
        }
        else
        {
            int pivotIndex = listCount / 2;
            string pivotElement = sortedList[pivotIndex];

            List<string> subListLeft = new List<string>();
            List<string> subListRight = new List<string>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            for (int i = pivotIndex + 1; i < listCount; i++)
            {
                if (sortedList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(sortedList[i]);
                }
                else
                {
                    subListRight.Add(sortedList[i]);
                }
            }

            subListLeft = SortGeneric(subListLeft);
            subListRight = SortGeneric(subListRight);

            List<string> resultList = new List<string>();
            resultList.AddRange(subListLeft);
            resultList.Add(pivotElement);
            resultList.AddRange(subListRight);

            return resultList;
        }
    }
}