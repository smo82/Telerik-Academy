using System;
using System.Collections.Generic;
using System.Threading;

//This is the Falling Rocks homework from the Console Input / Output lecture

class FallingRocks
{
    struct Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public void ChangePosition(int row, int col)
        {
            this.row += row;
            this.col += col;
        }
    }

    struct Rock
    {
        public char symbol;
        public int weight;
        public Position position;

        public Rock(char symbol, int weight, int row = 0, int col = 0)
        {
            this.symbol = symbol;
            this.weight = weight;
            this.position.row = row;
            this.position.col = col;
        }
    }

    static void Main()
    {
        byte maxNumberOfRocksPerRow = 3;
        Random randRocksPerRow = new Random();

        Queue<Rock> rocksQueue = new Queue<Rock> { };

        Position[] positions = new Position[]
        {
            new Position(0,1),
            new Position(0,-1)
        };

        Rock[] rocksArr = new Rock[]
        {
            new Rock ('^', 10),
            new Rock ('@', 20),
            new Rock ('*', 30),
            new Rock ('&', 40),
            new Rock ('+', 50),
            new Rock ('%', 60),
            new Rock ('$', 70),
            new Rock ('#', 80),
            new Rock ('!', 90),
            new Rock ('.', 100),
            new Rock (';', 110),
            new Rock ('-', 120)
        };

        int rockTotalWeight = 0;
        for (int i = 0; i < rocksArr.Length; i++)
        {
            rockTotalWeight = rocksArr[i].weight;
            rocksArr[i].weight = rockTotalWeight;
        }
        Random randRocksType = new Random();

        Position dworf = new Position(Console.WindowHeight - 1, Console.WindowWidth / 2 - 2);

        Console.BufferHeight = Console.WindowHeight;
        
        int rowNumber = 0;
        bool gameOn = true;
        ConsoleKeyInfo userInput;
        while (gameOn)
        {
            //Get the key press and move the dworf
            //If the user presses Escape the game ends
            if (Console.KeyAvailable)
            {
                userInput = Console.ReadKey();

                if ((userInput.Key == ConsoleKey.RightArrow) && (dworf.col < Console.WindowWidth - 4))
                {
                    dworf.ChangePosition(0, 1);
                }
                else if ((userInput.Key == ConsoleKey.LeftArrow) && (dworf.col > 0))
                {
                    dworf.ChangePosition(0, -1);
                }
                else if (userInput.Key == ConsoleKey.Escape)
                {
                    gameOn = false;
                    break;
                }
            };

            //Clear the Key buffer when the key is pressed several times
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }

            //Add random rocks to the Rocks Queue
            int randomRockWeight;
            int randomRockNumberPerRow = randRocksPerRow.Next(maxNumberOfRocksPerRow);
            Rock tempRock = new Rock();
            for (int i = 0; i < randomRockNumberPerRow; i++)
            {
                randomRockWeight = randRocksType.Next(rockTotalWeight);

                int k = 0;
                while (rocksArr[k].weight < randomRockWeight)
                {
                    k++;
                }

                rocksQueue.Enqueue(new Rock(rocksArr[k].symbol, rocksArr[k].weight, rowNumber, randRocksType.Next(Console.WindowWidth)));
            }

            Console.Clear();

            //We remove the rocks that are already under the last visible row
            try
            {
                tempRock = rocksQueue.Peek();

                while ((rowNumber - tempRock.position.row) > (Console.WindowHeight - 1))
                {
                    rocksQueue.Dequeue();
                    tempRock = rocksQueue.Peek();
                }
            }
            catch { }

            int currentRockRow = 0;
            //We visualize the rocks
            foreach (Rock rockInQueue in rocksQueue)
            {
                currentRockRow = rowNumber - rockInQueue.position.row;
                if ((currentRockRow == (Console.WindowHeight - 1)) &&
                    (rockInQueue.position.col >= dworf.col) &&
                    (rockInQueue.position.col <= (dworf.col + 2)))
                {
                    gameOn = false;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(rockInQueue.position.col, rowNumber - rockInQueue.position.row);
                    Console.Write(rockInQueue.symbol);
                }
            }

            Console.SetCursorPosition(dworf.col, dworf.row);
            Console.Write("(0)");
            Thread.Sleep(150);
            rowNumber++;
        }
        Console.Clear();
        //Console.SetCursorPosition((Console.WindowHeight / 2), (Console.WindowWidth / 2 - 5));
        Console.SetCursorPosition((Console.WindowWidth / 2 - 5), (Console.WindowHeight / 2));
        Console.WriteLine("************");
        Console.SetCursorPosition((Console.WindowWidth / 2 - 5), (Console.WindowHeight / 2) + 1);
        Console.WriteLine("*Game over!*");
        Console.SetCursorPosition((Console.WindowWidth / 2 - 5), (Console.WindowHeight / 2) + 2);
        Console.WriteLine("************");
    }
}