/*
 * Task02
 * 
 * Implement Quicksorter.Sort() method using quicksort algorithm
 */

namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            collection = this.CustomQuickSort((collection as List<T>));
        }

        private List<T> CustomQuickSort(List<T> elementsList)
        {
            if (elementsList.Count <= 1)
            {
                return elementsList;
            }

            int pivotIndex = elementsList.Count / 2;
            T pivotElement = elementsList[pivotIndex];

            List<T> subListLeft = new List<T>();
            List<T> subListRight = new List<T>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (elementsList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(elementsList[i]);
                }
                else
                {
                    subListRight.Add(elementsList[i]);
                }
            }

            for (int i = pivotIndex + 1; i < elementsList.Count; i++)
            {
                if (elementsList[i].CompareTo(pivotElement) < 0)
                {
                    subListLeft.Add(elementsList[i]);
                }
                else
                {
                    subListRight.Add(elementsList[i]);
                }
            }

            subListLeft = this.CustomQuickSort(subListLeft);
            subListRight = this.CustomQuickSort(subListRight);

            elementsList.Clear();
            elementsList.AddRange(subListLeft.ToArray<T>());
            elementsList.Add(pivotElement);
            elementsList.AddRange(subListRight);

            return elementsList;
        }
    }
}
