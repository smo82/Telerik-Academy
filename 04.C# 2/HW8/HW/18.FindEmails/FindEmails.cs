using System;
using System.Text.RegularExpressions;

class FindEmails
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        MatchCollection matches = Regex.Matches(userText, @"\b[\w\._-]+@[\w_-]+\.\w{2,6}\b");

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The e-mails found are:");
        foreach (Match match in matches)
	    {
            Console.WriteLine(match);
            match.NextMatch();
	    }
    }
}
