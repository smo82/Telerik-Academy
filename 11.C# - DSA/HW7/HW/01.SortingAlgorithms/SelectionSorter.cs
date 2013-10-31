/*
 * Task01
 * 
 * Implement SelectionSorter.Sort() method using selection sort algorithm
 */

namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                T minElement = collection[i];
                int minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(minElement) < 0)
                    {
                        minElement = collection[j];
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    T tempElement = collection[i];
                    collection[i] = minElement;
                    collection[minElementIndex] = tempElement;
                }
            }
        }
    }
}
