using System;

class ReadNumber
{
    static void Main()
    {
        Console.Write("Enter the your number:");
        int number;

        while ((!int.TryParse(Console.ReadLine(), out number)) || (number > 999))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        string numberRead = "";
        string and = "";
        int firstDigit = number % 10;
        int secondDigit = number / 10;
        secondDigit = secondDigit % 10;
        int thirdDigit = number / 100;



        if (secondDigit == 1)
        {
            and = "and ";

            switch (firstDigit)
            {
                case 0:
                    numberRead = "Ten";
                    break;
                case 1 :
                    numberRead = "Eleven";
                    break;
                case 2:
                    numberRead = "Twelve ";
                    break;
                case 3:
                    numberRead = "Thirteen";
                    break;
                case 4:
                    numberRead = "Fourteen";
                    break;
                case 5:
                    numberRead = "Fifteen";
                    break;
                case 6:
                    numberRead = "Sixteen";
                    break;
                case 7:
                    numberRead = "Seventeen";
                    break;
                case 8:
                    numberRead = "Eighteen";
                    break;
                case 9:
                    numberRead = "Nineteen";
                    break;
            }
        }
        else
        {
            switch (firstDigit)
            {
                case 1:
                    numberRead = "One";
                    break;
                case 2:
                    numberRead = "Two";
                    break;
                case 3:
                    numberRead = "Three";
                    break;
                case 4:
                    numberRead = "Four";
                    break;
                case 5:
                    numberRead = "Five";
                    break;
                case 6:
                    numberRead = "Six";
                    break;
                case 7:
                    numberRead = "Seven";
                    break;
                case 8:
                    numberRead = "Eight";
                    break;
                case 9:
                    numberRead = "Nine";
                    break;
            }

            switch (secondDigit)
            {
                case 1:
                    break;
                case 2:
                    numberRead = "Twenty " + numberRead;
                    break;
                case 3:
                    numberRead += "Thirty " + numberRead;
                    break;
                case 4:
                    numberRead += "Fourty " + numberRead;
                    break;
                case 5:
                    numberRead += "Fifty " + numberRead;
                    break;
                case 6:
                    numberRead += "Sixty " + numberRead;
                    break;
                case 7:
                    numberRead += "Seventy " + numberRead;
                    break;
                case 8:
                    numberRead += "Eightty " + numberRead;
                    break;
                case 9:
                    numberRead += "Ninety " + numberRead;
                    break;
                default :
                    if (numberRead != "")
                    {
                        and = "and ";
                    }
                    break;
            }
        }



        switch (thirdDigit)
        {
            case 1 :
                numberRead = "One Hundred " + and + numberRead;
                break;
            case 2:
                numberRead = "Two Hundred " + and + numberRead;
                break;
            case 3:
                numberRead = "Three Hundred " + and + numberRead;
                break;
            case 4:
                numberRead = "Four Hundred " + and + numberRead;
                break;
            case 5:
                numberRead = "Five Hundred " + and + numberRead;
                break;
            case 6:
                numberRead = "Six Hundred " + and + numberRead;
                break;
            case 7:
                numberRead = "Seven Hundred " + and + numberRead;
                break;
            case 8:
                numberRead = "Eight Hundred " + and + numberRead;
                break;
            case 9:
                numberRead = "Nine Hundred " + and + numberRead;
                break;
        }

        if (number == 0)
        {
            numberRead = "Zero";
        }

        Console.WriteLine("Your number is: " + numberRead);
    }
}
