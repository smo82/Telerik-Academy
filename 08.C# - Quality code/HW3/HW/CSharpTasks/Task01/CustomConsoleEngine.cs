using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    class CustomConsoleEngine
    {
        const int MAXIMAL_COUNT = 6;
        class CustomConsole
        {
            public void Write(bool input)
            {
                string inputAsString = input.ToString();
                Console.WriteLine(inputAsString);
            }
        }

        static void Main(string[] args)
        {
            CustomConsole customConsoleInstance = new CustomConsole();
            customConsoleInstance.Write(true);
        }
    }
}
