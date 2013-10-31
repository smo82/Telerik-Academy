namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Returns an MD5 hash of the string on which it is executed
        /// </summary>
        /// <param name="input">The string on which we want to generate an MD5 hash</param>
        /// <returns>Returns and MD5 hash of the input string as a string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Returns 'true' if a given string can be interpretated as true and returns 'false' otherwise
        /// The following strings are translated to 'true': {"true", "ok", "yes", "1", "да"}
        /// All other values are translated to 'false'.
        /// </summary>
        /// <param name="input">The string which we want to translate to a boolean value</param>
        /// <returns>Returns true or false depending on the way the input string was translated</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Tries to parse a given string to a short value
        /// </summary>
        /// <param name="input">The string we want to parse</param>
        /// <returns>Returns a short value if the parse succeeds or 0 otherwise</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Tries to parse a given string to an integer value
        /// </summary>
        /// <param name="input">The string we want to parse</param>
        /// <returns>Returns an integer value if the parse succeeds or 0 otherwise</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Tries to parse a given string to a long value
        /// </summary>
        /// <param name="input">The string we want to parse</param>
        /// <returns>Returns a long value if the parse succeeds or 0 otherwise</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Tries to parse a given string to a DateTime value
        /// </summary>
        /// <param name="input">The string we want to parse</param>
        /// <returns>Returns a DateTime value if the parse succeeds or {01.1.0001 00:00:00} otherwise</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Makes the first letter of the string a capital letter
        /// </summary>
        /// <param name="input">The string which we want to process</param>
        /// <returns>Returns the same string with its first letter made a capital letter. If the string is Null or Empty it is returned without a change</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Tries to find a substring in a given string that is positioned between to other substrings
        /// </summary>
        /// <param name="input">The string in which we search for the substring</param>
        /// <param name="startString">The starting substring after which starts the string we want to get</param>
        /// <param name="endString">The ending substring before which ends the string we want to get</param>
        /// <param name="startFrom">An index in the original string from which the search starts</param>
        /// <returns>A substring if the method succeeds or un empty string otherwise</returns>
        /// <example>  
        /// This sample shows how to call the <see cref="GetStringBetween"/> method.
        /// <code>
        /// /// class TestClass  
        /// { 
        ///     static void Main(string[] args)  
        ///     { 
        ///         string testString = "aaaaabc";
        ///         string testStringBetween = testString.GetStringBetween("a", "c", 2);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts a string with cyrillic letters to a string of latin letters that is a representation of the original
        /// </summary>
        /// <param name="input">The string we want to convert</param>
        /// <returns>The original string in which all cyrillinc letters are replaced with their latin analog</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts a string with latin letters to a string of cyrillic letters that is a representation of the original
        /// </summary>
        /// <param name="input">The string we want to convert</param>
        /// <returns>The original string in which all latin letters are replaced with their cyrillinc analog</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts a given string into a valid user name
        /// The result string is allowed to only contain latin letters, numbers, underscores (_), slashes (\) and full stops (.)
        /// </summary>
        /// <param name="input">The string we want to convert</param>
        /// <returns>Returns the original string in which all cyrillic letters are replaced with their latin analogs and all not allowed symbols are deleted</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts a string into a valid file name
        /// The result string is allowed to only contain latin letters, underscores (_), full stops (.) and dashes(-) 
        /// </summary>
        /// <param name="input">The string we want to convert</param>
        /// <returns>Returns the original string in which all cyrillic letters are replaced with their latin analogs, the spaces are replaced with dashes and all other not allowed symbols are deleted</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring of a given string with a given length or the whole string if it is not long enough 
        /// </summary>
        /// <param name="input">The string from which we want to get a substring</param>
        /// <param name="charsCount">The index up to which we want to get a substring</param>
        /// <returns>Returns a substring with the given length or the whole string if it is not long enough </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the file extension of a string if it contains a standard file name 
        /// </summary>
        /// <param name="fileName">The string that contains the file name</param>
        /// <returns>Returns the substring that starts after the last full stop of the original string or an empty string if unsuccessful</returns>
        /// <example>  
        /// This sample shows how to call the <see cref="GetFileExtension"/> method.
        /// <code>
        /// /// class TestClass  
        /// { 
        ///     static void Main(string[] args)  
        ///     { 
        ///         string testFileName = "example.jpg";
        ///         string testFileNameExtension = testFileName.GetFileExtension();
        ///     }
        /// }
        /// </code>
        /// </example> 
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type of a given file extension
        /// </summary>
        /// <param name="fileExtension">The file extension</param>
        /// <returns>Returns the content type corresponding to the file extension or "application/octet-stream" otherwise</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a given string to a byte array
        /// </summary>
        /// <param name="input">The string we want to convert</param>
        /// <returns>Returns an array of bytes corresponding to our string</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
