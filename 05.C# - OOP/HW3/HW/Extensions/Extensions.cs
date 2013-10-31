//Task01
//Implement an extension method Substring(int index, int length) for the class StringBuilder 
//that returns new StringBuilder and has the same functionality as Substring in the class String.

//Task02
//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.


using System;
using System.Text;
using System.Collections.Generic;

namespace ExtensionsAndOther
{
    public static class Extensions
    {
        //------
        //Task01
        //------
        public static StringBuilder Substring (this StringBuilder thisStringBuilder, int index, int length)
        {
            StringBuilder result = new StringBuilder();
            result.Append(thisStringBuilder.ToString().Substring(index, length));
            return result;
        }

        //------
        //Task02
        //------
        public static T Sum<T>(this IEnumerable<T> enumeration) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = 0;

            foreach (var value in enumeration)
            {
                result += value;
            }
            return result;
        }

        public static T Product<T>(this IEnumerable<T> enumeration) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = 1;

            foreach (var value in enumeration)
            {
                result *= value;
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> enumeration) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = null;

            foreach (var value in enumeration)
            {
                if ((result == null) || (result>value))
                {
                    result = value;
                }
            }
            return result;
        }

        public static T Max<T>(this IEnumerable<T> enumeration) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = null;

            foreach (var value in enumeration)
            {
                if ((result == null) || (result < value))
                {
                    result = value;
                }
            }
            return result;
        }

        public static T Count<T>(this IEnumerable<T> enumeration) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = 0;
            
            foreach (var value in enumeration)
            {
                result++;
            }
            return result;
        }

        public static T Average<T>(this IEnumerable<T> enumeration) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = enumeration.Sum<T>();

            result = result/enumeration.Count();

            return result;
        }
    }
}
