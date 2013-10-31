//Task08
//Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

//Task09
//Implement an indexer this[row, col] to access the inner matrix cells.

//Task10
//Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
//Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

using System;
using System.Text;

namespace Generic
{
    //------
    //Task08
    //------
    public class Matrix<T> : IComparable<Matrix<T>> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T[,] matrix;

        public int Rows { get; set; }
        public int Cols { get; set; }

        //Constructor
        public Matrix (T [,] pMatrix)
        {
            this.matrix = pMatrix;
            this.Rows = pMatrix.GetLength(0);
            this.Cols = pMatrix.GetLength(1);
        }

        //Constructor 2
        public Matrix (int pRows, int pCols)
        {
            this.matrix = new T[pRows, pCols];
            this.Rows = pRows;
            this.Cols = pCols;
        }

        //------
        //Task09
        //------
        public T this [int row, int col]
        {
            get
            {
                if (this.Rows <= row)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", row));
                }
                else if (this.Cols <= col)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", col));
                }
                else
                {
                    return this.matrix[row, col];
                }
            }
            set 
            {
                if (this.Rows <= row)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", row));
                }
                else if (this.Cols <= col)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", col));
                }
                else
                {
                    this.matrix[row, col] = value;
                }
            }
        }

        //------
        //Task10
        //------
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Cols != secondMatrix.Cols))
            {
                throw new ArgumentException("The matrixes are not the same size.");
            }
            else
            {
                int newMatrixRows = firstMatrix.Rows;
                int newMatrixCols = firstMatrix.Cols;
                Matrix<T> newMatrix = new Matrix<T>(newMatrixRows, newMatrixCols);
                for (int i = 0; i < newMatrixRows; i++)
                {
                    for (int j = 0; j < newMatrixCols; j++)
                    {
                        newMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    }
                }

                return newMatrix;
            }
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Cols != secondMatrix.Cols))
            {
                throw new ArgumentException("The matrixes are not the same size.");
            }
            else
            {
                int newMatrixRows = firstMatrix.Rows;
                int newMatrixCols = firstMatrix.Cols;
                Matrix<T> newMatrix = new Matrix<T>(newMatrixRows, newMatrixCols);
                for (int i = 0; i < newMatrixRows; i++)
                {
                    for (int j = 0; j < newMatrixCols; j++)
                    {
                        newMatrix[i, j] = (dynamic)firstMatrix[i, j] - (dynamic)secondMatrix[i, j];
                    }
                }

                return newMatrix;
            }
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.Rows != secondMatrix.Rows) || (firstMatrix.Cols != secondMatrix.Cols))
            {
                throw new ArgumentException("The matrixes are not the same size.");
            }
            else
            {
                int newMatrixRows = firstMatrix.Rows;
                int newMatrixCols = secondMatrix.Cols;
                Matrix<T> newMatrix = new Matrix<T>(newMatrixRows, newMatrixCols);

                for (int i = 0; i < newMatrixRows; i++)
                {
                    for (int j = 0; j < newMatrixCols; j++)
                    {
                        dynamic product = 0;
                        for (int k = 0; k < firstMatrix.Cols; k++)
                        {
                            product += (dynamic)firstMatrix[i, k] * (dynamic)secondMatrix[k, j];
                        }
                        newMatrix[i, j] = product;
                    }
                }

                return newMatrix;
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            bool result = false;

            int rowsIndex = 0;
            while (!result && rowsIndex < matrix.Rows)
            {
                int colsIndex = 0;
                while (!result && colsIndex < matrix.Cols)
                {
                    result = (dynamic)matrix[rowsIndex, colsIndex] != 0;
                    colsIndex++;
                }
                rowsIndex++;
            }

            return result;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool result = true;

            int rowsIndex = 0;
            while (result && rowsIndex < matrix.Rows)
            {
                int colsIndex = 0;
                while (result && colsIndex < matrix.Cols)
                {
                    result = (dynamic)matrix[rowsIndex, colsIndex] == 0;
                    colsIndex++;
                }
                rowsIndex++;
            }

            return result;
        }

        public T SumElements()
        {
            dynamic sum = 0;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    sum += this.matrix[i, j];
                }
            }

            return sum;
        }

        public int CompareTo(Matrix <T> that)
        {
            int thisSize = this.Rows + this.Cols;
            int thatSize = that.Rows + that.Cols;
            if (thisSize < thatSize) return -1;
            if (thisSize == thatSize)
            {
                T sumThis = this.SumElements();
                T sumThat = that.SumElements();
                return sumThis.CompareTo(sumThat);
            }
            return 1;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    result.Append(this.matrix[i, j] + " ");
                }
                result.Remove(result.Length - 1, 1);
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
