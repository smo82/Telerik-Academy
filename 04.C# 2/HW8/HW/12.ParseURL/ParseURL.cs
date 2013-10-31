using System;
using System.Text.RegularExpressions;

class ParseURL
{
    static void Main()
    {
        Console.Write("Enter your URL address:");
        string userURL = Console.ReadLine();

        MatchCollection matches = Regex.Matches(userURL, @"^(?<protocol>\w+?)://(?<server>w+(\.\w+)*?)/(?<resource>\w+(/\w+)*(\.\w+)?)");
        
        Console.WriteLine(new String('*', 20));
        if (matches.Count == 0)
        {
            Console.WriteLine("Parse failed!");
        }
        else
        {
            Console.WriteLine("Your result string is:");
            Console.WriteLine("[protocol] = {0}", matches[0].Groups["protocol"]);
            Console.WriteLine("[server] = {0}", matches[0].Groups["server"]);
            Console.WriteLine("[resource] = /{0}", matches[0].Groups["resource"]);
        }
    }
}
