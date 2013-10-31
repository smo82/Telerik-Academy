//Task12
//Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
// - Create an instance of the GSM class.
// - Add few calls.
// - Display the information about the calls.
// - Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
// - Remove the longest call from the history and calculate the total price again.
// - Finally clear the call history and print it.

using System;
using GSMSpace;

namespace GSMCallHistoryTestProject
{
    //-------
    //Task12
    //-------
    public class GSMCallHistoryTest
    {
        //Fills the GSM with some random calls
        public static GSM FillGSMCalls(GSM currentGSM)
        {
            currentGSM.AddCall(new Call(40, DateTime.Now, "0888 888 888"));
            currentGSM.AddCall(new Call(190, DateTime.Now, "0888 888 888"));
            currentGSM.AddCall(new Call(130, DateTime.Now, "0888 888 888"));

            return currentGSM;
        }
        
        static void Main(string[] args)
        {
            GSM testGSM = new GSM("1000", "Nokia");
            testGSM = FillGSMCalls(testGSM);

            Console.WriteLine(new String ('*', 20));
            Console.WriteLine("List all calls:");
            Console.WriteLine(testGSM.ListAllCalls());

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("The price of all calls is: {0}", testGSM.CalcAllCallPrice((decimal)0.37));

            int indexMaxCall = 0;
            for (int i = 1; i < testGSM.CallHistory.Count; i++)
            {
                if (testGSM.CallHistory[indexMaxCall].Duration < testGSM.CallHistory[i].Duration)
                {
                    indexMaxCall = i;
                }
            }

            testGSM.RemoveCall(indexMaxCall);
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("The new price of all calls is: {0}", testGSM.CalcAllCallPrice((decimal)0.37));

            testGSM.RemoveAllCalls();
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("List all calls:");
            Console.WriteLine(testGSM.ListAllCalls());
        }
    }
}
