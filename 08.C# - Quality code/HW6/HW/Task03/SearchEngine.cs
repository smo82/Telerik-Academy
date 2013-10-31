//Task03
//Refactor the following loop: 

using System;

class SearchEngine
{
    static void Main(string[] args)
    {
        int [] array = new int[100];
        int expectedValue = 0;
        
        bool valueFound = false;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(array[i]);
            bool indexIsDevisibleBy10 = (i % 10 == 0);
            if (indexIsDevisibleBy10 && (array[i] == expectedValue))
            {
                valueFound = true;
                break;
            }
        }
        
        // More code here

        //In the original code when the value was found the code sets it to 666 and after that increments it one more time (makes it 667)
        //This way the code in this if-statement is always unreachable. I assume that this was and error and for that reason desided to  
        //make the check as if i == 666 (as if we indicate that the searched value is found)
        if (valueFound)
        {
            Console.WriteLine("Value Found");
        }
    }
}
