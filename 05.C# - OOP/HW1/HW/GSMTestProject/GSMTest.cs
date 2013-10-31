//Task 7
//Write a class GSMTest to test the GSM class:
// - Create an array of few instances of the GSM class.
// - Display the information about the GSMs in the array.
// - Display the information about the static property IPhone4S.

using System;
using GSMSpace;

namespace GSMTestSpace
{
    public class GSMTest
    {
        //Method to fill a GSM array with some inital data. The method is also used in the GSMAutoTestProject for unit testing
        public static GSM[] FillArrayGSM()
        {
            GSM[] gsmArray = new GSM[4];
            //First constructor
            gsmArray[0] = new GSM("1000", "Nokia");
            //Second constructor
            gsmArray[1] = new GSM("Lumia 620", "Nokia", (decimal)249.99, "Simo");
            gsmArray[2] = new GSM("Asha 310", "Nokia", (decimal)102, "Ivo", new Battery("BL-5CB", 200, 5, BatteryType.NiMH), new Display((decimal)3.0, 65000));
            //Third constructor
            gsmArray[3] = new GSM("X2-02", "Nokia", "BL-5CB", (decimal)70, "Ivan", new Display(3, 65000), 50, 6);

            return gsmArray;
        }
        public static void Main()
        {
            GSM[] gsmArray = FillArrayGSM();

            Console.WriteLine("GSM array info:");
            for (int i = 0; i < gsmArray.Length; i++)
            {
                Console.WriteLine("{0} : {1}", i, gsmArray[i]);
            }

            Console.WriteLine(new String ('*', 20));
            Console.WriteLine("IPhone4S info: {0}", GSM.IPhone4S);
            GSM.IPhone4S = "No-info";
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("IPhone4S new info: {0}", GSM.IPhone4S);
        }
    }
}
