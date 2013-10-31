using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class MinesweeperEngine
    {
        const int MAX_POSSIBLE_SCORE = 35;
        const int MAIN_BOARD_NUMBER_OF_ROWS = 5;
        const int MAIN_BOARD_NUMBER_OF_COLUMNS = 10;
        const int TOTAL_NUMBER_OF_BOMBS = 15;
        static readonly int MainBoardTotalNumberOfFields = MAIN_BOARD_NUMBER_OF_ROWS * MAIN_BOARD_NUMBER_OF_COLUMNS;

        public static void Main(string[] arguments)
        {
            string playerInput = string.Empty;
            char[,] gameBoard = GenerateGameBoard();
            char[,] bombBoard = GenerateBombBoard();
            List<Score> highScore = new List<Score>(6);
            int currentScore = 0;
            int chosenRow = 0;
            int chosenColumn = 0;
            bool newGameFlag = true;
            bool gameWonFlag = false;
            bool mineFoundFlag = false;

            do
            {
                if (newGameFlag)
                {
                    Console.Clear();
                    Console.WriteLine("Lets play Minesweeper!");
                    Console.WriteLine(new String('-', 40));
                    Console.WriteLine("RowNumber ColumnNumber - Reveals the content of the cell at that position");
                    Console.WriteLine("highscore              - Show the high score");
                    Console.WriteLine("newgame                - New game");
                    Console.WriteLine("exit                   - Exit game");
                    Console.WriteLine(new String('-', 40));
                    DisplayBoard(gameBoard);
                    newGameFlag = false;
                }
                Console.Write("Please enter cell column and row or another command: ");
                playerInput = Console.ReadLine().Trim();

                //Check if the user have entered correct row and column numbers
                if ((playerInput.Length >= 3) &&
                    int.TryParse(playerInput[0].ToString(), out chosenRow) &&
                    int.TryParse(playerInput[2].ToString(), out chosenColumn) &&
                    chosenRow <= MAIN_BOARD_NUMBER_OF_ROWS &&
                    chosenColumn <= MAIN_BOARD_NUMBER_OF_COLUMNS)
                {
                    playerInput = "turn";
                }

                switch (playerInput)
                {
                    case "highscore":
                        HighScoreBoardDisplay(highScore);
                        break;
                    case "newgame":
                        newGameFlag = true;
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (bombBoard[chosenRow, chosenColumn] != '*')
                        {
                            if (bombBoard[chosenRow, chosenColumn] == '-')
                            {
                                ProcessSuccessfulTurn(gameBoard, bombBoard, chosenRow, chosenColumn);
                                currentScore++;
                            }

                            if (MAX_POSSIBLE_SCORE == currentScore)
                            {
                                gameWonFlag = true;
                            }
                            else
                            {
                                DisplayBoard(gameBoard);
                            }
                        }
                        else
                        {
                            mineFoundFlag = true;
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect command! Please try again:");
                        break;
                }

                if (mineFoundFlag)
                {
                    DisplayBoardRevealed(bombBoard);
                    Console.WriteLine();
                    Console.WriteLine("Mine found. Your score is: {0} points. ", currentScore);
                    Console.Write("Please enter your name: ");
                    string userName = Console.ReadLine();
                    Score userScore = new Score(userName, currentScore);

                    RefreshHighScore(userScore, ref highScore);

                    gameBoard = GenerateGameBoard();
                    bombBoard = GenerateBombBoard();
                    currentScore = 0;
                    mineFoundFlag = false;
                    newGameFlag = true;
                }

                if (gameWonFlag)
                {
                    Console.WriteLine();
                    Console.WriteLine("Game won! Congratulations.");
                    DisplayBoardRevealed(bombBoard);
                    Console.WriteLine("Please enter your name: ");

                    string userName = Console.ReadLine();
                    Score userScore = new Score(userName, currentScore);

                    RefreshHighScore(userScore, ref highScore);

                    gameBoard = GenerateGameBoard();
                    bombBoard = GenerateBombBoard();
                    currentScore = 0;
                    gameWonFlag = false;
                    newGameFlag = true;
                }
            }
            while (playerInput != "exit");
            Console.Read();
        }

        private static void RefreshHighScore(Score userScore, ref List<Score> highScore)
        {
            if (highScore.Count < 5)
            {
                highScore.Add(userScore);
            }
            else
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    if (highScore[i].Points < userScore.Points)
                    {
                        highScore.Insert(i, userScore);
                        highScore.RemoveAt(highScore.Count - 1);
                        break;
                    }
                }
            }

            highScore.Sort((Score score1, Score score2) => score2.Name.CompareTo(score1.Name));
            highScore.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
        }

        private static void HighScoreBoardDisplay(List<Score> highScore)
        {
            Console.WriteLine();
            Console.WriteLine("High Score:");
            if (highScore.Count > 0)
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points",
                        i + 1, highScore[i].Name, highScore[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty High Score.");
            }
        }

        private static void ProcessSuccessfulTurn(char[,] gameBoard, char[,] bombBoard, int chosenRow, int chosenColumn)
        {
            char numberOfSurroundingBombs = GetNumberOfSurroundingBombs(bombBoard, chosenRow, chosenColumn);
            bombBoard[chosenRow, chosenColumn] = numberOfSurroundingBombs;
            gameBoard[chosenRow, chosenColumn] = numberOfSurroundingBombs;
        }

        private static void DisplayBoard(char[,] board)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < MAIN_BOARD_NUMBER_OF_ROWS; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < MAIN_BOARD_NUMBER_OF_COLUMNS; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static void DisplayBoardRevealed(char[,] board)
        {
            GameBoardRevealed(board);
            DisplayBoard(board);
        }

        private static void GameBoardRevealed(char[,] board)
        {
            for (int i = 0; i < MAIN_BOARD_NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < MAIN_BOARD_NUMBER_OF_COLUMNS; j++)
                {
                    if (board[i, j] != '*')
                    {
                        board[i, j] = GetNumberOfSurroundingBombs(board, i, j);
                    }
                }
            }
        }

        private static char[,] GenerateGameBoard()
        {
            char[,] board = new char[MAIN_BOARD_NUMBER_OF_ROWS, MAIN_BOARD_NUMBER_OF_COLUMNS];
            for (int i = 0; i < MAIN_BOARD_NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < MAIN_BOARD_NUMBER_OF_COLUMNS; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateBombBoard()
        {
            char[,] bombBoard = new char[MAIN_BOARD_NUMBER_OF_ROWS, MAIN_BOARD_NUMBER_OF_COLUMNS];

            for (int i = 0; i < MAIN_BOARD_NUMBER_OF_ROWS; i++)
            {
                for (int j = 0; j < MAIN_BOARD_NUMBER_OF_COLUMNS; j++)
                {
                    bombBoard[i, j] = '-';
                }
            }

            List<int> listOfBombs = new List<int>();
            while (listOfBombs.Count < TOTAL_NUMBER_OF_BOMBS)
            {
                Random random = new Random();
                int newBombPossition = random.Next(MainBoardTotalNumberOfFields);
                if (!listOfBombs.Contains(newBombPossition))
                {
                    listOfBombs.Add(newBombPossition);
                }
            }

            foreach (int bombPossition in listOfBombs)
            {
                int currentBombColumn = (bombPossition / MAIN_BOARD_NUMBER_OF_COLUMNS);
                int currentBombRow = (bombPossition % MAIN_BOARD_NUMBER_OF_COLUMNS);
                if (currentBombRow == 0 && bombPossition != 0)
                {
                    currentBombColumn--;
                    currentBombRow = MAIN_BOARD_NUMBER_OF_COLUMNS;
                }
                else
                {
                    currentBombRow++;
                }
                bombBoard[currentBombColumn, currentBombRow - 1] = '*';
            }

            return bombBoard;
        }

        private static char GetNumberOfSurroundingBombs(char[,] board, int selectedColumn, int selectedRow)
        {
            int numberOfSurroundingBombs = 0;

            if ((selectedColumn - 1 >= 0) && (board[selectedColumn - 1, selectedRow] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedColumn + 1 < MAIN_BOARD_NUMBER_OF_ROWS) && (board[selectedColumn + 1, selectedRow] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedRow - 1 >= 0) && (board[selectedColumn, selectedRow - 1] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedRow + 1 < MAIN_BOARD_NUMBER_OF_COLUMNS) && (board[selectedColumn, selectedRow + 1] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedColumn - 1 >= 0) && (selectedRow - 1 >= 0) && (board[selectedColumn - 1, selectedRow - 1] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedColumn - 1 >= 0) && (selectedRow + 1 < MAIN_BOARD_NUMBER_OF_COLUMNS) && (board[selectedColumn - 1, selectedRow + 1] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedColumn + 1 < MAIN_BOARD_NUMBER_OF_ROWS) && (selectedRow - 1 >= 0) && (board[selectedColumn + 1, selectedRow - 1] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            if ((selectedColumn + 1 < MAIN_BOARD_NUMBER_OF_ROWS) && (selectedRow + 1 < MAIN_BOARD_NUMBER_OF_COLUMNS) && (board[selectedColumn + 1, selectedRow + 1] == '*'))
            {
                numberOfSurroundingBombs++;
            }
            return char.Parse(numberOfSurroundingBombs.ToString());
        }
    }
}
