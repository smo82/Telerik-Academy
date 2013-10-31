using System;

class QuatationStrings
{
    static void Main()
    {
        string qString1 = "The \"use\" of quotations causes difficulties.";
        string qString2 = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine(qString1);
        Console.WriteLine(qString2);
    }
}
