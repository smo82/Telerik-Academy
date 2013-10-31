/*
 * Task06
 * 
 * A text file phones.txt holds information about people, their town and phone number:
 * Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
 * Kireto                  | Varna    | 052 23 45 67
 * Daniela Ivanova Petrova | Karnobat | 0899 999 888
 * Bat Gancho              | Sofia    | 02 946 946 946
 * 
 * Duplicates can occur in people names, towns and phone numbers. 
 * Write a program to read the phones file and execute a sequence of commands given in the file commands.txt:
 * - find(name) – display all matching records by given name (first, middle, last or nickname)
 * - find(name, town) – display all matching records by given name and town
 */

using System;
using System.IO;
using System.Collections.Generic;

class PhonebookMain
{
    static void Main(string[] args)
    {
        Phonebook phonebook = new Phonebook();
        using (StreamReader inputReader = new StreamReader("phones.txt"))
        {
            String line = inputReader.ReadLine();
            while (line != null)
            {
                string[] lineWords = line.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                string names = lineWords[0].Trim();
                string town = lineWords[1].Trim();
                string phone = lineWords[2].Trim();

                PhoneRecord record = new PhoneRecord(names, town, phone);
                phonebook.Add(record);
                line = inputReader.ReadLine();
            }
        }

        using (StreamReader inputReader = new StreamReader("commands.txt"))
        {
            String line = inputReader.ReadLine();
            while (line != null)
            {
                string[] comandParameters = line.Split(new string[] { "find(", ")", ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                List<PhoneRecord> results;
                if (comandParameters.Length == 2)
                {
                    string names = comandParameters[0].Trim();
                    string town = comandParameters[1].Trim();

                    results = phonebook.Find(names, town);
                }
                else
                {
                    string names = comandParameters[0].Trim();
                    results = phonebook.Find(names);
                }

                Console.WriteLine(new String('*', 30));
                Console.WriteLine("Result from command {0}", line);
                PrintPhoneRecordList(results);

                line = inputReader.ReadLine();
            }
        }
    }

    private static void PrintPhoneRecordList(List<PhoneRecord> records)
    {
        foreach (PhoneRecord record in records)
        {
            Console.WriteLine("{0} | {1} | {2}", record.NamesAsString, record.Town, record.Phone);
        }
    }
}