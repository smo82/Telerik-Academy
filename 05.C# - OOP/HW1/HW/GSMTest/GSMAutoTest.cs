//Task 7
//Write a class GSMTest to test the GSM class:
// - Create an array of few instances of the GSM class.
// - Display the information about the GSMs in the array.
// - Display the information about the static property IPhone4S.

//Task12
//Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
// - Create an instance of the GSM class.
// - Add few calls.
// - Display the information about the calls.
// - Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
// - Remove the longest call from the history and calculate the total price again.
// - Finally clear the call history and print it.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSMSpace;
using GSMCallHistoryTestProject;

namespace GSMTestSpace
{
    /// <summary>
    /// Tests of the GSM class
    /// </summary>
    [TestClass]
    public class GSMAutoTest 
    {        
        [TestMethod]
        public void TestMethod1()
        {
            GSM[] gsmArray = GSMTest.FillArrayGSM();
            string[] resultsArray = new string[] { 
                "Nokia - 1000 - ? - ?",
                "Nokia - Lumia 620 - Simo - 249.99",
                "Nokia - Asha 310 - Ivo - 102.00",
                "Nokia - X2-02 - Ivan - 70.00"
            };

            //Test all GSMs display ID
            for (int i = 0; i < gsmArray.Length; i++)
            {
                Assert.AreEqual(resultsArray[i], gsmArray[i].ToString());
            }

            //Check GSM iPhone4S info
            Assert.AreEqual("Apple iPhone 4S smartphone. Announced 2011, October. Features 3G, 3.5\" LED-backlit IPS LCD display, 8 MP camera, Wi-Fi, GPS, Bluetooth.", GSM.IPhone4S);

            //Check GSM iPhone4S info after change
            GSM.IPhone4S = "No-info";
            Assert.AreEqual("No-info", GSM.IPhone4S);
        }

        [TestMethod]
        public void TestMethod2()
        {
            GSM testGSM = GSMCallHistoryTest.FillGSMCalls(new GSM("1000", "Nokia"));

            string testResultString = "";
            
            //Check all calls display
            testResultString = String.Format("1 : To 0888 888 888 at {0} for 40 seconds\r\n2 : To 0888 888 888 at {0} for 190 seconds\r\n3 : To 0888 888 888 at {0} for 130 seconds\r\n", DateTime.Now);
            Assert.AreEqual(testResultString, testGSM.ListAllCalls());

            //Check all calls price
            Assert.AreEqual((decimal)2.96, testGSM.CalcAllCallPrice((decimal)0.37));
            
            //Check all calls price withoud the longest call
            int indexMaxCall = 0;
            for (int i = 1; i < testGSM.CallHistory.Count; i++)
            {
                if (testGSM.CallHistory[indexMaxCall].Duration < testGSM.CallHistory[i].Duration)
                {
                    indexMaxCall = i;
                }
            }
            testGSM.RemoveCall(indexMaxCall);
            
            Assert.AreEqual((decimal)1.48, testGSM.CalcAllCallPrice((decimal)0.37));

            //Check all calls list when empty
            testGSM.RemoveAllCalls();
            Assert.AreEqual("", testGSM.ListAllCalls());
        }
    }
}
