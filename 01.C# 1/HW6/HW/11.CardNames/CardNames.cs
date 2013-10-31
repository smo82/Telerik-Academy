using System;

class CardNames
{
    static void Main()
    {
        Console.WriteLine("We will display the names of all playing cards");

        string cardType = "";
        string cardName = "";
        for (byte i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1:
                    cardType = "spades";
                    break;
                case 2:
                    cardType = "hearts";
                    break;
                case 3:
                    cardType = "diamonds";
                    break;
                case 4:
                    cardType = "clubs";
                    break;
            }
            for (int j = 2; j <= 14; j++)
            {
                switch (j)
                {
                    case 2:
                        cardName = "Two";
                        break;
                    case 3:
                        cardName = "Three";
                        break;
                    case 4:
                        cardName = "Four";
                        break;
                    case 5:
                        cardName = "Five";
                        break;
                    case 6:
                        cardName = "Six";
                        break;
                    case 7:
                        cardName = "Seven";
                        break;
                    case 8:
                        cardName = "Eight";
                        break;
                    case 9:
                        cardName = "Nine";
                        break;
                    case 10:
                        cardName = "Ten";
                        break;
                    case 11:
                        cardName = "Jack";
                        break;
                    case 12:
                        cardName = "Queen";
                        break;
                    case 13:
                        cardName = "King";
                        break;
                    case 14:
                        cardName = "Ace";
                        break;
                }

                Console.WriteLine(cardName + " of " + cardType);
            }
        }
    }
}
