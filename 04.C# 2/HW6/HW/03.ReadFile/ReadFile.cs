using System;

class ReadFile
{
    static void Main()
    {
        Console.Write("Enter the file name:");
        string fileName = Console.ReadLine();

        Console.Write("Enter the file path:");
        string filePath = Console.ReadLine() + fileName;

        try
        {
            string fileContent = System.IO.File.ReadAllText(@filePath);
            Console.WriteLine(fileContent);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("File path is empty");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid file path!");
        }
        catch (System.IO.PathTooLongException)
        {
            Console.WriteLine("File path too long!");
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Unauthorized access!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in an invalid format!");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("You don't have the required permission!");
        }
    }
}
