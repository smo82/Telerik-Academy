using System;

class StringMatch
{
    static void Main()
    {
        Console.Write("Enter char array number 1:");
        string charArray1 = Console.ReadLine();
        Console.Write("Enter char array number 2:");
        string charArray2 = Console.ReadLine();

        if (charArray1.Length != charArray2.Length)
        {
            Console.WriteLine("The char arrays are not equal!");
        }
        else
        {
            int charArrayLength = 0;

            while ((charArrayLength < charArray1.Length) && (charArray1[charArrayLength] == charArray2[charArrayLength]))
            {
                charArrayLength++;
            }

            if (charArrayLength == charArray1.Length)
            {
                Console.WriteLine("The char arrays are equal");
            }
            else
            {
                Console.WriteLine("The char arrays are not equal!");
            }
        }
    }
}
