using System;
using System.Collections.Generic;

class ZeroSum
{
    //The method returns the sum of all combinations of N elements (N = level)
    //from a list of elements (numbersList)

    //This means for example that when level = 2 the method will return the sum
    //of all pairs from the list of elements
    static List <int> RecursiveListSum(int level, List <int> numbersList)
    {
        List<int> numbersSubList = new List<int> (numbersList);
        List<int> numberSubListSum = new List<int> { };
        List<int> numberListSum = new List<int> { };

        if (level == 1)
        {
            return numbersList;
        }
        else
        {
            foreach (int numberListItem in numbersList)
            {
                numbersSubList.Remove(numberListItem);

                //Gets the sums of all combinations from the lower lever
                //For example when our level is 3 we get one element, then we
                //construct a list with the rest of the items and we get all
                //sums of this items ny pairs(level 2). After we get all this
                //sums we add to each of them "our" current element. This way we
                //get the sum of our element with all possible pairs.
                //After that we repeat with the next element
                numberSubListSum = RecursiveListSum(--level, numbersSubList);

                foreach (int subListSumItem in numberSubListSum)
                {
                    numberListSum.Add(numberListItem + subListSumItem);
                }
            }
        }
        return numberListSum;
    }

    static void Main()
    {
        byte listLenght = 5;
        List<int> numbers = new List<int> { };
        int tempListVal = 0;

        for (int i = 0; i < listLenght; i++)
        {
            Console.WriteLine("Enter number {0}:", i + 1);

            while (!int.TryParse(Console.ReadLine(), out tempListVal))
            {
                Console.WriteLine("Incorrect number, please enter it again:");
            }
            numbers.Add(tempListVal);
        }

        //We check if some of the elements is 0
        if (numbers.Exists(c => c == 0))
        {
            Console.WriteLine("There is a subset of elements with zero sum!");
        }
        else
        {
            List<int> sumList = new List<int> { };
            int levelCheck = listLenght;
            bool zeroSumFlag = false;
            
            //We build the sums of all combinations of elements
            //First we get the sum of all elements (for example - all 5 elements)
            //Then we get the sum of all combinations of the elements from
            //the lower level (for example 5-1 = 4 : we get all combinations of 4 elements)
            //and so on..
            //When we get a sum that is equal to zero we stop the loop
            while ((levelCheck > 1) && (zeroSumFlag == false))
            {
                sumList = RecursiveListSum(levelCheck, numbers);
                if (sumList.Exists(c => c == 0))
                {
                    zeroSumFlag = true;
                }
                levelCheck--;
            }

            if (zeroSumFlag)
            {
                Console.WriteLine("There is a subset of elements with zero sum!");
            }
            else
            {
                Console.WriteLine("There is no zero sum subset!");
            }
        }
        
    }
}
