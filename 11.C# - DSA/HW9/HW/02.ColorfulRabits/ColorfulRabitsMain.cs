using System;
using System.Collections.Generic;

class ColorfulRabitsMain
{
    static void Main(string[] args)
    {
        int numberOfAsks = int.Parse(Console.ReadLine());

        Dictionary<int, int> rabitAnswers = new Dictionary<int, int>();

        for (int i = 0; i < numberOfAsks; i++)
        {
            int answer = int.Parse(Console.ReadLine());
            if (rabitAnswers.ContainsKey(answer))
            {
                rabitAnswers[answer]++;
            }
            else
            {
                rabitAnswers[answer] = 1;
            }
        }

        int rabitCount = 0;

        foreach (KeyValuePair<int,int> item in rabitAnswers)
        {
            int rabitAnswer = item.Key + 1;
            int rabitAnswerCount = item.Value;
            while (rabitAnswerCount > rabitAnswer)
            {
                rabitCount += rabitAnswer;
                rabitAnswerCount -= rabitAnswer;
            }

            rabitCount += rabitAnswer;
        }

        Console.WriteLine(rabitCount);
    }
}