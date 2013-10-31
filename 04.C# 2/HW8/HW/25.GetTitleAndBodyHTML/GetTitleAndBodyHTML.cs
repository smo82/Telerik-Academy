using System;
using System.IO;
using System.Text.RegularExpressions;

class GetTitleAndBodyHTML
{
    static void Main()
    {
        string input = "input.txt";

        try
        {
            StreamReader inputFile = new StreamReader(input);

            string text = inputFile.ReadToEnd();
            text = Regex.Replace(text, "\\s+", " ");

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Results:");
            
            //Get title
            MatchCollection titleMatches = Regex.Matches(text, @"<title>(?<title>.*)</title>");
            
            if (titleMatches.Count>0)
            {
                Console.WriteLine("[title] = {0}", titleMatches[0].Groups["title"].ToString());
            }

            //Remove title from text
            text = Regex.Replace(text, @"<title>.*</title>", "");

            //Get body text
            MatchCollection bodyMatches = Regex.Matches(text, @">(?<body>[^<>]*)<", RegexOptions.Multiline);

            Console.WriteLine("[body text] :");

            foreach (Match bodyTextMatch in bodyMatches)
            {
                if (bodyTextMatch.Groups["body"].ToString().Trim() != "")
                {
                    Console.WriteLine(bodyTextMatch.Groups["body"]);
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the input file!");
        }
    }
}
