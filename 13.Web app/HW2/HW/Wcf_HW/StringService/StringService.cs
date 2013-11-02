using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringService
{
    public class StringService : IStringService
    {
        public int CountSubstringOccurrences(string subString, string mainString)
        {
            int countOccurances = 0;
            int indexStart = mainString.IndexOf(subString);
            while (indexStart != -1)
            {
                countOccurances++;
                indexStart = mainString.IndexOf(subString, indexStart + subString.Length);
            }

            return countOccurances;
        }
    }
}
