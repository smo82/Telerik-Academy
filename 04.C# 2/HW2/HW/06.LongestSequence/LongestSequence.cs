using System;

class LongestSequence
{
    static int ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static string [,] ReadArray(int numberElementsX, int numberElementsY)
    {
        string [,] elementsList = new string [numberElementsX, numberElementsY];

        for (int i = 0; i < numberElementsY; i++)
        {
            for (int j = 0; j < numberElementsX; j++)
            {
                Console.Write("[{0},{1}]:", i, j);
                elementsList[j, i] = Console.ReadLine();
            }
            Console.WriteLine();
        }

        return elementsList;
    }

    static void Main()
    {
        int numberElementsX = ReadInt("Enter the number of elements by X:");
        int numberElementsY = ReadInt("Enter the number of elements by Y:");

        string [,] elementsList = new string [numberElementsX, numberElementsY];
        elementsList = ReadArray(numberElementsX, numberElementsY);

        int maxSequenceLength = 0;
        string maxSequence = "";

        //Check for horizontal sequences
        for (int i = 0; i < numberElementsX; i++)
        {
            int currentSequenceLength = 0;
            string currentString = "";
            string currentSequence = "";
            for (int j = 0; j < numberElementsY; j++)
            {
                if (elementsList[i, j] == currentString)
                {
                    currentSequenceLength++;
                    currentSequence += currentString + ", ";
                }
                else
                {
                    currentString = elementsList[i, j];
                    currentSequenceLength = 1;
                    currentSequence = currentString + ", ";
                }

                if (maxSequenceLength < currentSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequence = currentSequence;
                }
            }
        }

        //Check for horizontal sequences
        for (int i = 0; i < numberElementsY; i++)
        {
            int currentSequenceLength = 0;
            string currentString = "";
            string currentSequence = "";
            for (int j = 0; j < numberElementsX; j++)
            {
                if (elementsList[j, i] == currentString)
                {
                    currentSequenceLength++;
                    currentSequence += currentString + ", ";
                }
                else
                {
                    currentString = elementsList[j, i];
                    currentSequenceLength = 1;
                    currentSequence = currentString + ", ";
                }

                if (maxSequenceLength < currentSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequence = currentSequence;
                }
            }
        }

        //Check for left-to-right diagonals
        int startIndexY = numberElementsY - 1;
        int startIndexX = 0;
        while (startIndexX < numberElementsX - 1)
        {
            if (startIndexY == 0)
            {
                startIndexX++;
            }
            else
            {
                startIndexY--;
            }

            int indexX = startIndexX;
            int indexY = startIndexY;

            int currentSequenceLength = 0;
            string currentString = "";
            string currentSequence = "";
            while ((indexX < numberElementsX) && (indexY < numberElementsY))
            {
                if (elementsList[indexX, indexY] == currentString)
                {
                    currentSequenceLength++;
                    currentSequence += currentString + ", ";
                }
                else
                {
                    currentString = elementsList[indexX, indexY];
                    currentSequenceLength = 1;
                    currentSequence = currentString + ", ";
                }

                if (maxSequenceLength < currentSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequence = currentSequence;
                }

                indexX++;
                indexY++;
            }
        }

        //Check for right-to-left diagonals
        startIndexX = 0;
        startIndexY = 0;
        while (startIndexY < numberElementsY - 1)
        {
            if (startIndexX < numberElementsX-1)
            {
                startIndexX++;
            }
            else
            {
                startIndexY++;
            }

            int indexX = startIndexX;
            int indexY = startIndexY;

            int currentSequenceLength = 0;
            string currentString = "";
            string currentSequence = "";
            while ((indexX >= 0) && (indexY < numberElementsY))
            {
                if (elementsList[indexX, indexY] == currentString)
                {
                    currentSequenceLength++;
                    currentSequence += currentString + ", ";
                }
                else
                {
                    currentString = elementsList[indexX, indexY];
                    currentSequenceLength = 1;
                    currentSequence = currentString + ", ";
                }

                if (maxSequenceLength < currentSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequence = currentSequence;
                }

                indexX--;
                indexY++;
            }
        }

        maxSequence = maxSequence.Substring(0, maxSequence.Length - 2);
        Console.WriteLine("The longest sequence is made of {0} elements and is: {1}", maxSequenceLength, maxSequence);
    }
}
