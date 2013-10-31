/*
 * Task03
 * 
 * Implement MergeSorter.Sort() method using merge sort algorithm
 */

namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            collection = this.CustomMergeSort((collection as List<T>));
        }

        private List<T> CustomMergeSort(List<T> elementsArr)
        {
            if (elementsArr.Count <= 1)
            {
                return elementsArr;
            }

            int middle = elementsArr.Count / 2;

            T[] subArrayLeft = new T[middle];
            Array.Copy(elementsArr.ToArray<T>(), 0, subArrayLeft, 0, middle);
            subArrayLeft = this.CustomMergeSort(subArrayLeft.ToList<T>()).ToArray<T>();

            T[] subArrayRight = new T[elementsArr.Count - middle];
            Array.Copy(elementsArr.ToArray<T>(), middle, subArrayRight, 0, elementsArr.Count - middle);
            subArrayRight = this.CustomMergeSort(subArrayRight.ToList<T>()).ToArray<T>();

            int elementsCount = elementsArr.Count;
            int indexLeftArr = 0;
            int indexRightArr = 0;
            elementsArr.Clear();

            for (int i = 0; i < elementsCount; i++)
            {
                if (indexLeftArr == subArrayLeft.Length)
                {
                    elementsArr.Add(subArrayRight[indexRightArr]);
                    indexRightArr++;
                }
                else if (indexRightArr == subArrayRight.Length)
                {
                    elementsArr.Add(subArrayLeft[indexLeftArr]);
                    indexLeftArr++;
                }
                else if (subArrayLeft[indexLeftArr].CompareTo(subArrayRight[indexRightArr]) < 0)
                {
                    elementsArr.Add(subArrayLeft[indexLeftArr]);
                    indexLeftArr++;
                }
                else
                {
                    elementsArr.Add(subArrayRight[indexRightArr]);
                    indexRightArr++;
                }
            }

            return elementsArr;
        }
    }
}
