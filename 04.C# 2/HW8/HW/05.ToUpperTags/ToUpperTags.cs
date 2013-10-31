using System;
using System.Text;
class ToUpperTags
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        int startIndex = userString.IndexOf("<upcase>");
        int endIndex = userString.IndexOf("</upcase>");
        int firstIndexOtherString = 0;
        StringBuilder resultString = new StringBuilder();
        
        while ((startIndex >= 0) && (endIndex >= 0))
        {
            resultString.Append(userString.Substring(firstIndexOtherString, startIndex - firstIndexOtherString));

            string subStringToChange = userString.Substring(startIndex + 8, endIndex - startIndex - 8);

            resultString.Append(subStringToChange.ToUpper());
            firstIndexOtherString = endIndex + 9;

            startIndex = userString.IndexOf("<upcase>", startIndex+1);
            endIndex = userString.IndexOf("</upcase>", endIndex+1);
        }

        if (firstIndexOtherString < userString.Length - 1)
        {
            resultString.Append(userString.Substring(firstIndexOtherString));
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result string is: {0}", resultString);
    }
}
