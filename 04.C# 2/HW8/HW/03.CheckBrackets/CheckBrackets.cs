using System;

class CheckBrackets
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        int bracketCounter = 0;
        int indexNextBracket = userString.IndexOfAny(new char[] {'(', ')'});

        while ((indexNextBracket >= 0) && (bracketCounter >=0))
        {
            char currentBracket = userString[indexNextBracket];
            if (currentBracket == '(')
            {
                bracketCounter++;
            }
            else if (currentBracket == ')')
            {
                bracketCounter--;
            }
            indexNextBracket = userString.IndexOfAny(new char[] {'(', ')'}, indexNextBracket+1);
        }

        Console.WriteLine(new String('*', 20));
        if (bracketCounter == 0)
        {
            Console.WriteLine("The brackets are correct.");
        }
        else
        {
            Console.WriteLine("The brackets are not correct");
        }
    }
}
