using System;

class PasswordCountMain
{
    static void Main(string[] args)
    {
        string passwordTemplate = Console.ReadLine();

        ulong passwordCount = CountPasswordCombinations(passwordTemplate);
        Console.WriteLine(passwordCount);
    }

    private static ulong CountPasswordCombinations(string passwordTemplate)
    {
        if (passwordTemplate == string.Empty)
        {
            return 0;
        }

        ulong passwordCount = 1;

        for (int i = 0; i < passwordTemplate.Length; i++)
        {
            if (passwordTemplate[i] == '*')
            {
                passwordCount *= 2;
            }
        }

        return passwordCount;
    }
}