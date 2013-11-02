using System;
using System.Globalization;
using System.Linq;

namespace DateService
{
    public class DateService : IDateService
    {
        public string GetWeekDayInBg(DateTime date)
        {
            string dateAsString = date.ToString("dddd", CultureInfo.CreateSpecificCulture("bg-BG"));
            dateAsString = char.ToUpper(dateAsString[0]) + dateAsString.Substring(1);
            return dateAsString;
        }
    }
}
