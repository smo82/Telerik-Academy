using System;
using System.Collections.Generic;

class CalcSumInt
{
    static void Main()
    {
        bool checkOK = false;
        string sequenceString = String.Empty;
        string[] sequenceStringArr = new string[0];
        List<int> sequenceIntList = new List<int>();
        
        while (!checkOK)
        {
            Console.Write("Enter your sequence of numbers:");
            sequenceString = Console.ReadLine();
            sequenceStringArr = sequenceString.Split(' ');
            checkOK = true;
            sequenceIntList.Clear();
            int index = 0;
            while ((checkOK) && (index < sequenceStringArr.Length))
            {
                int currentNumber;
                if (int.TryParse(sequenceStringArr[index], out currentNumber))
                {
                    sequenceIntList.Add(currentNumber);
                }
                else
                {
                    checkOK = false;
                }
                index++;
            }
        }

        int sum = 0;

        foreach (int item in sequenceIntList)
        {
            sum += item;
        }

        Console.WriteLine("The sum of your numbers is: {0}", sum);
    }
}
