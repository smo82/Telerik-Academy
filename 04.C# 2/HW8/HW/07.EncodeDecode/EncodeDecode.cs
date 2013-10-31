using System;
using System.Text;

class EncodeDecode
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        Console.Write("Enter your cipher:");
        string userCipher = Console.ReadLine();

        StringBuilder result = new StringBuilder();
        int indexCipher = 0;

        for (int i = 0; i < userString.Length; i++)
        {
            result.Append((char)(userString[i] ^ userCipher[indexCipher]));
            if (indexCipher == userCipher.Length - 1)
            {
                indexCipher = 0;
            }
            else
            {
                indexCipher++;
            }
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result string is:{0}", result);
    }
}