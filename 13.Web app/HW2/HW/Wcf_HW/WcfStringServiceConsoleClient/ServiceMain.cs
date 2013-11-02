using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfStringServiceConsoleClient
{
    class ServiceMain
    {
        static void Main(string[] args)
        {
            StringServiceClient client = new StringServiceClient();

            Console.WriteLine("Main string: 'tatata'");
            Console.WriteLine("Substring searched: 'ta'");
            Console.WriteLine("The result is: {0}", client.CountSubstringOccurrences("ta", "tatata"));
        }
    }
}
