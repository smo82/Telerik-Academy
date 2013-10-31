using System;
using System.Text;

class Crossword
{
    //Checks the partially filled crossword - a crossword for which not all words on the horizontal are set)
    //Checks if all words on the vertical can be match to words from the words array
    static bool CheckPartialCrossword(int n, string[] crossword, string[] words)
    {
        bool result = true;

        int indexCrosswordWord = 0;
        while (result && (indexCrosswordWord < n))
        {
            StringBuilder buildWord = new StringBuilder();
            int indexBuildWord = 0;
            while ((indexBuildWord < n) && (crossword[indexBuildWord] != null))
            {
                buildWord.Append(crossword[indexBuildWord][indexCrosswordWord]);
                indexBuildWord++;
            }

            bool innerMatch = false;
            int indexWord = 0;
            while (!innerMatch && (indexWord < 2 * n))
            {
                if (words[indexWord].IndexOf(buildWord.ToString()) >=0)
                {
                    innerMatch = true;
                }
                indexWord++;
            }

            result = innerMatch;
            indexCrosswordWord++;
        }

        return result;
    }

    //Checks a filled crossword - a crossword for which all words on the horizontal are set
    static bool CheckCrossword (int n, string[] crossword, string[] words)
    {
        StringBuilder word = new StringBuilder();
        int indexWord = 0;
        word.Append(words[0]);
        while ((indexWord < n) && (Array.IndexOf(words, word.ToString()) >= 0))
        {
            word.Clear();
            for (int i = 0; i < n; i++)
            {
                word.Append(crossword[i][indexWord]);
            }
            indexWord++;
        }

        if (indexWord == n)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //A method which by recurtion tries all combinations of words in the crossword
    static string[] BuildCrossword(int n, string[] crossword, string[] words)
    {
        string [] result = new string[n];
        int indexEmpty = 0;

        while ((indexEmpty <n) && (crossword[indexEmpty] != null))
        {
            indexEmpty++;
        }

        if ((indexEmpty == n) && (CheckCrossword(n, crossword, words)))
        {
            crossword.CopyTo(result,0);
        }
        else if (CheckPartialCrossword(n, crossword, words))
        {
            string[] tempCrossword = new string[n];
            int indexNextWord = 0;
            while ((indexNextWord < 2 * n) && (result[0] == null))
            {
                crossword.CopyTo(tempCrossword, 0);
                tempCrossword[indexEmpty] = words[indexNextWord];
                result = BuildCrossword(n, tempCrossword, words);
                indexNextWord++;
            }
        }

        return result;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] words = new string[2 * n];

        for (int i = 0; i < 2*n; i++)
        {
            words[i] = Console.ReadLine();
        }

        Array.Sort(words);

        string[] crossword = new string[n];

        crossword = BuildCrossword(n, crossword, words);

        if (crossword[0] == null)
        {
            Console.WriteLine("NO SOLUTION!");
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(crossword[i]);
            }
        }
    }
}
