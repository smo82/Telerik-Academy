using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.DataServiceReference;

namespace WcfClient
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            DateServiceClient client = new DateServiceClient();
            DateTime currentDate = new DateTime(2013, 8, 6);
            string currentDayAsBgString = client.GetWeekDayInBg(currentDate);
            Console.WriteLine("The day in BG for date {0} is {1}", currentDate, currentDayAsBgString);
        }
    }
}
