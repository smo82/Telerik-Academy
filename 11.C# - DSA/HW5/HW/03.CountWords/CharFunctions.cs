using System;

public class CharFunctions
{
    public static int CharToIndex(char currentChar)
    {
        if (currentChar < 'A')
        {
            return currentChar - '0';
        }
        else if (currentChar < 'a')
        {
            return currentChar - 'A';
        }
        else
        {
            return currentChar - 'a' + 26;
        }
    }
}
