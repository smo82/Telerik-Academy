//Task05
//Define a class BitArray64 to hold 64 bit values inside an ulong value. 
//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

using System;
using System.Collections.Generic;
using System.Collections;

namespace StudentSystem
{
    //------
    //Task05
    //------
    class BitArray64 : IEnumerable<int>
    {
        public List<long> Values { get; private set; }

        public BitArray64 ()
        {
            this.Values = new List<long>();
        }

        public BitArray64 (List<long> pValues)
            :this ()
        {
            this.Values.AddRange(pValues);
        }

        public void Add (long newValue)
        {
            this.Values.Add(newValue);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Values.Count; i++)
            {
                yield return i;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            BitArray64 that = obj as BitArray64;
            if (that == null)
                return false;
            if (this.Values.Count != that.Values.Count)
                return false;

            for (int i = 0; i < this.Values.Count; i++)
            {
                if (this.Values[i] != that.Values[i])
                    return false;
            }

            return true;
        }

        public static bool operator ==(BitArray64 firstBitArray, BitArray64 secondBitArray){
            return firstBitArray.Equals(secondBitArray);
        }

        public static bool operator !=(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return !(firstBitArray.Equals(secondBitArray));
        }

        public override int GetHashCode()
        {
            int resultHashCode = this.Values.GetHashCode();

            //For bigger lists we don't process all values, because this would be too slow
            int step = this.Values.Count / 10 + 1;
            for (int i = 0; i < this.Values.Count; i+= step)
            {
                resultHashCode ^= this.Values[i].GetHashCode();
            }

            return resultHashCode;
        }

        public long this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this.Values.Count))
                    throw new ArgumentOutOfRangeException(String.Format("Invalid index ({0})!", index));

                return this.Values[index];
            }
            set
            {
                if ((index < 0) || (index >= this.Values.Count))
                    throw new ArgumentOutOfRangeException(String.Format("Invalid index ({0})!", index));

                this.Values[index] = value;
            }
        }
    }
}
