using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.ILS.Common
{
    class StringExtensionsEngine
    {
        static void Main(string[] args)
        {
            string testString = "abcd *_(";
            string testStringAsHash = testString.ToMd5Hash();
            bool testStringAsBoolean = testString.ToBoolean();
            short testStringAsShort = testString.ToShort();
            int testStringAsInt = testString.ToInteger();
            long testStringAsLong = testString.ToLong();
            DateTime testStringAsDateTime = testString.ToDateTime();
            string testStringCapitalized = testString.CapitalizeFirstLetter();
            string testStringBetween = testString.GetStringBetween("a", "c", 2);
            string testStringInCyrillic = testString.ConvertLatinToCyrillicKeyboard();
            string testStringInLatin = testStringInCyrillic.ConvertCyrillicToLatinLetters();
            string testStringAsValidUserName = testString.ToValidUsername();
            string testStringAsValidFileName = testString.ToValidLatinFileName();
            string substringOfTest = testString.GetFirstCharacters(3);
            string testFileName = "example.jpg";
            string testFileNameExtension = testFileName.GetFileExtension();
            string testFileNameContentType = testFileNameExtension.ToContentType();
            byte[] testFileNameAsByteArray = testFileName.ToByteArray();
        }
    }
}
