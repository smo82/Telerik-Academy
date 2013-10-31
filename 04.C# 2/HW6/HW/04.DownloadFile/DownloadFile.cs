using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        Console.Write("Enter the file URL:");
        string url = Console.ReadLine();

        Console.Write("Enter the destination path:");
        string destinationPath = Console.ReadLine();

        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile(url, destinationPath);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The URL is null!");
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (NotSupportedException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
