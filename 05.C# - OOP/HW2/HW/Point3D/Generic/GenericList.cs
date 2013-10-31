//Task05
//Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
//Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
//Implement methods for adding element, accessing element by index, removing element by index, 
//inserting element at given position, clearing the list, finding element by its value and ToString(). 
//Check all input parameters to avoid accessing elements at invalid positions.

//Task06
//Implement auto-grow functionality: when the internal array is full, 
//create a new array of double size and move all elements to it.

//Task07
//Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
//You may need to add a generic constraints for the type T.

using System;
using System.Text;

namespace Generic
{
    //------
    //Task05
    //------
    //------
    //Task06
    //------
    public class GenericList <T> where T : IComparable<T>
    {
        T[] listElements;
        
        public int Count { get; set; }

        //Constructor
        public GenericList (T [] arrElements)
        {
            T[] newListElements = new T[arrElements.Length * 2];
            arrElements.CopyTo(newListElements, 0);

            this.listElements = newListElements;
            this.Count = arrElements.Length;
        }

        public void AddElement (T element)
        {
            T[] newListElements;
            if (this.Count == this.listElements.Length)
            {
                newListElements = new T[this.listElements.Length * 2];
                this.listElements.CopyTo(newListElements, 0);
            }
            else
            {
                newListElements = this.listElements;
            }

            newListElements[this.Count] = element;
            this.Count++;
            this.listElements = newListElements;
        }

        public void RemoveElement (int index)
        {
            if ((this.Count > 0) && (index >= 0) && (index < this.Count))
            {
                T [] newListElements = new T[this.listElements.Length];
                int indexNewList = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    if (i != index)
                    {
                        newListElements[indexNewList] = this.listElements[i];
                        indexNewList++;
                    }
                }

                this.listElements = newListElements;
                this.Count--;
            }
            else
            {
                throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
            }
        }

        public void InsertElement (int index, T newElement)
        {
            if ((index >= 0) && (index <= this.Count))
            {
                T[] newListElements;
                if (this.Count == this.listElements.Length)
                {
                    newListElements = new T[this.listElements.Length * 2];
                }
                else
                {
                    newListElements = new T[this.listElements.Length];
                }
                
                int indexOldList = 0;
                for (int i = 0; i <= this.Count; i++)
                {
                    if (i == index)
                    {
                        newListElements[i] = newElement;
                    }
                    else
                    {
                        newListElements[i] = this.listElements[indexOldList];
                        indexOldList++;
                    }
                }

                this.listElements = newListElements;
                this.Count++;
            }
            else
            {
                throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
            }
        }

        public void Clear()
        {
            this.listElements = new T [32];
            this.Count = 0;
        }

        public bool FindElementIndex (T element, out int index)
        {
            index = 0;
            while ((index < this.Count) && (this.listElements [index].CompareTo(element) != 0))
                index++;

            if (index == this.Count)
                return false;
            else
                return true;
        }

        public T this [int index]
        {
            get
            {
                if (index < this.Count)
                {
                    return this.listElements[index];
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
            }
            set
            {
                if (index < this.Count)
                {
                    this.listElements[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                T item = this.listElements[i];
                result.AppendLine(item.ToString());
            }
            return result.ToString();
        }

        //------
        //Task07
        //------
        public T Min()
        {
            T result = this.listElements[0];

            for (int i = 1; i < this.Count; i++)
            {
                T element = this.listElements[i];
                if (result.CompareTo(element) > 0)
                {
                    result = element;
                }
            }

            return result;
        }

        public T Max()
        {
            T result = this.listElements[0];

            for (int i = 1; i < this.Count; i++)
            {
                T element = this.listElements[i];
                if (result.CompareTo(element) < 0)
                {
                    result = element;
                }
            }

            return result;
        }
    }
}
