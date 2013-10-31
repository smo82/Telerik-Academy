//Tesk06
//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Linq;

namespace ExtensionsAndOther
{
    public static class IntArrMethods
    {
        //------
        //Task06
        //------
        public static int[] GetDevisibleBy3And7Lambda(int[] inputArr)
        {
            return inputArr.Where(
                x => (x % 3 == 0) && (x % 7 == 0)
            ).ToArray();
        }

        public static int[] GetDevisibleBy3And7LINQ(int[] inputArr)
        {
            var intArrFiltered =
                from item in inputArr
                where (item % 3 == 0) && (item % 7 == 0)
                select item;
            return intArrFiltered.ToArray();
        }
    }
}
