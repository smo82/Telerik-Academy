using System;

class CopyrightTriangle
{
    static void Main()
    {
        char specialChar = '©';
        byte rows = 20;
        string spaceSymbols = "";
        string specialSymbols = "";

        byte symbolsPerRow = (byte)((rows * 2) - 1);
        byte nomerOfSpecialSymbols = 0;
        byte nomerOfSpaceSymbols = 0;

        for (byte i = 1; i <= rows; i++)
        {	
	        nomerOfSpecialSymbols = (byte)(i*2 - 1);
	        specialSymbols = new String(specialChar, nomerOfSpecialSymbols);
	        nomerOfSpaceSymbols = (byte)((symbolsPerRow - nomerOfSpecialSymbols) / 2);
	        spaceSymbols = new String(' ', nomerOfSpaceSymbols);
	
            Console.WriteLine(spaceSymbols + specialSymbols + spaceSymbols);
        }

    }
}
