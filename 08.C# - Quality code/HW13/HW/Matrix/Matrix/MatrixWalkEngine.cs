using log4net.Config;

namespace MatrixNamespace
{
    using System;
    using log4net;

    public class MatrixWalkEngine
    {
        private const int DIRECTIONS_COUNT = 8;
        private static readonly int[] DIRECTION_X = {1, 1, 1, 0, -1, -1, -1, 0};
        private static readonly int[] DIRECTION_Y = {1, 0, -1, -1, -1, 0, 1, 1};
        private static readonly ILog log = LogManager.GetLogger("TestLog4Net");

        public static void Main()
        {
            BasicConfigurator.Configure();
            // int n = 5;
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                log.Error("User error attempt to generate a matrix of rang: " + input);
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            DirectionSet2D directionSet = new DirectionSet2D(DIRECTIONS_COUNT, DIRECTION_X, DIRECTION_Y);
            Matrix matrix = new Matrix(n, directionSet);
            WalkEntireMatrix(matrix);
            matrix.PrintMatrix();
        }

        public static void WalkEntireMatrix(Matrix matrix)
        {
            int stepNumber = 1;
            int indexX;
            int indexY;
            while (matrix.FindEmptyCell(out indexX, out indexY))
            {
                var walkLenght = WalkMatrixPath(matrix, indexX, indexY, stepNumber);
                stepNumber += walkLenght;
            }
        }

        public static int WalkMatrixPath(Matrix matrix, int indexX, int indexY, int startStep)
        {
            IDirectionSet2D matrixDirectionSet = matrix.DirectionSet;
            Direction2D direction2D = new Direction2D(matrixDirectionSet);

            matrix[indexX, indexY] = startStep;
            var walkLenght = 1;
            while (matrix.IsChangeDirectionPossible(indexX, indexY))
            {
                int deltaX;
                int deltaY;
                direction2D.GetDelta(out deltaX, out deltaY);
                while (!matrix.IsValidEmptyCell(indexX + deltaX, indexY + deltaY))
                {
                    direction2D.Increase();
                    direction2D.GetDelta(out deltaX, out deltaY);
                }

                indexX += deltaX;
                indexY += deltaY;

                matrix[indexX, indexY] = startStep + walkLenght;
                walkLenght++;
            }

            return walkLenght;
        }
    }
}