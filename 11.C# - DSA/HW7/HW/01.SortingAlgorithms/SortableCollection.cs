/*
 * Task04
 * 
 * Implement SortableCollection.LinearSearch() method using linear search
 * Don’t use built-in search methods. Write your own.
 * 
 * Task05
 * 
 * Implement SortableCollection.BinarySearch() method using binary search algorithm
 * 
 * Task06
 * 
 * Implement SortableCollection.Shuffle() method using shuffle algorithm of your choice
 * Document what is the complexity of the algorithm
 */

namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T currentItem in this.items)
            {
                if (item.CompareTo(currentItem) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            if (this.items.Count == 0)
            {
                return false;
            }

            int lowerBorderIndex = 0;
            int upperBorderIndex = this.items.Count - 1;

            // We check the border cases. If our number is bigger then the biggest element or smaller then the smallest
            // then we know it is not present in the array
            if ((item.CompareTo(this.items[lowerBorderIndex]) < 0) || (item.CompareTo(this.items[upperBorderIndex]) > 0))
            {
                return false;
            }

            while (upperBorderIndex - lowerBorderIndex >= 0)
            {
                int currentIndex = (upperBorderIndex + lowerBorderIndex) / 2;

                T currentNumer = this.items[currentIndex];
                if (currentNumer.CompareTo(item) == 0)
                {
                    return true;
                }
                else if (currentNumer.CompareTo(item) > 0)
                {
                    upperBorderIndex = currentIndex - 1;
                }
                else
                {
                    lowerBorderIndex = currentIndex + 1;
                }
            }

            return false;
        }

        // ----------------------------------------------------
        // The complexity of the algorithm is O(n)
        // ----------------------------------------------------
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int randomIndex = random.Next(0, i);
                T transientValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = transientValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
