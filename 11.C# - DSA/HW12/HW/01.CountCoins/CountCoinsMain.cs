/*
 * Task01
 * 
 * You are given a set of infinite number of coins (1, 2 and 5) and end value – N. 
 * Write an algorithm that gives the number of coins needed so that the sum of the coins equals N. 
 * 
 * Example:   
 * N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1 = 8 coins
 */

using System;

class CountCoinsMain
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the sum you want to count:");
        int sum = int.Parse(Console.ReadLine());

        int numberOfCoins = 0;

        numberOfCoins = sum / 5;
        sum = sum % 5;

        numberOfCoins += sum / 2;
        sum = sum % 2;

        numberOfCoins += sum;

        Console.WriteLine("The number of coins needed is: {0}", numberOfCoins);
    }
}
