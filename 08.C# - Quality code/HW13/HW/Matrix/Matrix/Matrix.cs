namespace MatrixNamespace
{
    using System;

    public class Matrix
    {
        public Matrix(int rang, IDirectionSet2D directionSet)
        {
            this.Grid = new int[rang,rang];
            this.DirectionSet = directionSet;
        }

        public int[,] Grid { get; set; }

        public IDirectionSet2D DirectionSet { get; private set; }

        public int this[int indexX, int indexY]
        {
            get
            {
                if (indexX < 0 || indexX >= this.Grid.Length)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The X index should be between 0 and {0}", this.Grid.GetLength(0) - 1));
                }

                if (indexY < 0 || indexY >= this.Grid.Length)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The Y index should be between 0 and {0}", this.Grid.GetLength(1) - 1));
                }

                return this.Grid[indexX, indexY];
            }

            set
            {
                if (indexX < 0 || indexX >= this.Grid.Length)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The X index should be between 0 and {0}", this.Grid.GetLength(0) - 1));
                }

                if (indexY < 0 || indexY >= this.Grid.Length)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The Y index should be between 0 and {0}", this.Grid.GetLength(1) - 1));
                }

                this.Grid[indexX, indexY] = value;
            }
        }

        public bool IsValidEmptyCell(int indexX, int indexY)
        {
            if (indexX >= this.Grid.GetLength(0))
            {
                return false;
            }

            if (indexX < 0)
            {
                return false;
            }

            if (indexY >= this.Grid.GetLength(1))
            {
                return false;
            }

            if (indexY < 0)
            {
                return false;
            }

            if (this.Grid[indexX, indexY] != 0)
            {
                return false;
            }

            return true;
        }

        public bool IsChangeDirectionPossible(int indexX, int indexY)
        {
            Direction2D direction = new Direction2D(this.DirectionSet);

            for (int i = 0; i < 8; i++)
            {
                int deltaX;
                int deltaY;
                direction.GetDelta(out deltaX, out deltaY);

                if (this.IsValidEmptyCell(indexX + deltaX, indexY + deltaY))
                {
                    return true;
                }

                direction.Increase();
            }

            return false;
        }

        public bool FindEmptyCell(out int indexX, out int indexY)
        {
            indexX = -1;
            indexY = -1;
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grid.GetLength(0); j++)
                {
                    if (this.Grid[i, j] == 0)
                    {
                        indexX = i;
                        indexY = j;
                        return true;
                    }
                }
            }

            return false;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grid.GetLength(1); j++)
                {
                    Console.Write("{0,3}", this.Grid[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}