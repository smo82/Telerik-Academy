using System;

class AsciiTable
{
    static void Main()
    {
        int startSymbolNumber = 0;
        int endSymbolNumber = 255;
        char symbol = ' ';

        for (int i = startSymbolNumber; i <= endSymbolNumber; i++)
        {
            symbol = (char)i;
            Console.WriteLine("Symbol: {0}; ASCII code: {1} ", symbol, i);
        }

    }
}