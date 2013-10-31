using System;

class Matrix
{
    int[,] matrix;
    int rows;
    int cols;

    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
        this.rows = rows;
        this.cols = cols;
    }

    public Matrix(int rows) : this (rows, rows)
    {}

    public void FillMatrix ()
    {
        Console.WriteLine("Please enter the matrix content:");

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                Console.Write("[{0},{1}]:", i, j);
                while (!int.TryParse(Console.ReadLine(), out this.matrix[i, j])) 
                {
                    Console.Write("Wrong number. Please try again:");
                }
            }
        }
    }

    public int GetElement (int indexRow, int indexCol)
    {
        return this.matrix[indexRow, indexCol];
    }

    public int GetElement (int indexRow)
    {
        return GetElement(indexRow, indexRow);
    }

    public void SetElement (int indexRow, int indexCol, int value)
    {
        this.matrix[indexRow, indexCol] = value;
    }

    public static Matrix SumMatrices (Matrix firstMatrix, Matrix secondMatrix)
    {
        if ((firstMatrix.rows != secondMatrix.rows) || (firstMatrix.cols != secondMatrix.cols))
        {
            return new Matrix(0);
        }
        else
        {
            int newMatrixRows = firstMatrix.rows;
            int newMatrixCols = firstMatrix.cols;
            Matrix newMatrix = new Matrix(newMatrixRows, newMatrixCols);
            for (int i = 0; i < newMatrixRows; i++)
            {
                for (int j = 0; j < newMatrixCols; j++)
                {
                    newMatrix.SetElement(i, j, firstMatrix.GetElement(i, j) + secondMatrix.GetElement(i, j));
                }
            }

            return newMatrix;
        }
    }

    public static Matrix SubtractMatrices(Matrix firstMatrix, Matrix secondMatrix)
    {
        if ((firstMatrix.rows != secondMatrix.rows) || (firstMatrix.cols != secondMatrix.cols))
        {
            return new Matrix(0);
        }
        else
        {
            int newMatrixRows = firstMatrix.rows;
            int newMatrixCols = firstMatrix.cols;
            Matrix newMatrix = new Matrix(newMatrixRows, newMatrixCols);
            for (int i = 0; i < newMatrixRows; i++)
            {
                for (int j = 0; j < newMatrixCols; j++)
                {
                    newMatrix.SetElement(i, j, firstMatrix.GetElement(i, j) - secondMatrix.GetElement(i, j));
                }
            }

            return newMatrix;
        }
    }
    public static Matrix MultiplyMatrices(Matrix firstMatrix, Matrix secondMatrix)
    {
        if (firstMatrix.cols != secondMatrix.rows)
        {
            return new Matrix(0);
        }
        else
        {
            int newMatrixRows = firstMatrix.rows;
            int newMatrixCols = secondMatrix.cols;
            Matrix newMatrix = new Matrix(newMatrixRows, newMatrixCols);

            for (int i = 0; i < newMatrixRows; i++)
            {
                for (int j = 0; j < newMatrixCols; j++)
                {
                    int product = 0;
                    for (int k = 0; k < firstMatrix.cols; k++)
                    {
                        product += firstMatrix.GetElement(i, k) * secondMatrix.GetElement(k, j);
                    }
                    newMatrix.SetElement(i, j, product);
                }
            }

            return newMatrix;
        }
    }

    public string ToString()
    {
        string result = "";
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                result += this.matrix[i, j] + ", ";
            }
        }

        return result.Substring(0, result.Length - 2);
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                Console.Write("{0,3}", this.matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}

class MatrixClass
{
    static int ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static void Main()
    {
        //Summerize Matrices
        int sumMatrixRows = ReadInt("Please enter the number of rows for the matrices that will be summerized: ");
        int sumMatrixCols = ReadInt("Please enter the number of columns for the matrices that will be summerized: ");

        Matrix firstSumMatrix = new Matrix(sumMatrixRows, sumMatrixCols);
        Matrix secondSumMatrix = new Matrix(sumMatrixRows, sumMatrixCols);

        Console.WriteLine("Please fill the first matrix:");
        firstSumMatrix.FillMatrix();
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Please fill the second matrix:");
        secondSumMatrix.FillMatrix();

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The result of the sum of the matrices is:");
        Matrix sumMatrix = Matrix.SumMatrices(firstSumMatrix, secondSumMatrix);
        Console.WriteLine("As string:");
        Console.WriteLine(sumMatrix.ToString());
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("As matrix:");
        sumMatrix.PrintMatrix();

        Console.WriteLine(new String('*', 20));
        
        //Substract Matrices
        int substractMatrixRows = ReadInt("Please enter the number of rows for the matrices that will be subtracted: ");
        int substractMatrixCols = ReadInt("Please enter the number of columns for the matrices that will be subtracted: ");

        Matrix firstSubstractMatrix = new Matrix(substractMatrixRows, substractMatrixCols);
        Matrix secondSubstractMatrix = new Matrix(substractMatrixRows, substractMatrixCols);

        Console.WriteLine("Please fill the first matrix:");
        firstSubstractMatrix.FillMatrix();
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Please fill the second matrix:");
        secondSubstractMatrix.FillMatrix();

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The result of the subtraction of the matrices is:");
        Matrix substractMatrix = Matrix.SubtractMatrices(firstSubstractMatrix, secondSubstractMatrix);
        substractMatrix.PrintMatrix();
        
        //Multiply Matrices
        Console.WriteLine("We will multiply matrices!");
        int multiplyMatrixColsRows = ReadInt("Please enter the number of \"columns for the first matrix\"/\"rows for the second matrix\": ");
        int multiplyMatrixRowsFirstMatrix = ReadInt("Please enter the number of columns for the first matrix: ");
        int multiplyMatrixColsSecondMatrix = ReadInt("Please enter the number of rows for the second matrix: ");

        Matrix firstMultiplyMatrix = new Matrix(multiplyMatrixRowsFirstMatrix, multiplyMatrixColsRows);
        Matrix secondMultiplyMatrix = new Matrix(multiplyMatrixColsRows, multiplyMatrixColsSecondMatrix);

        Console.WriteLine("Please fill the first matrix:");
        firstMultiplyMatrix.FillMatrix();
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Please fill the second matrix:");
        secondMultiplyMatrix.FillMatrix();

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The result of the multiplication of the matrices is:");
        Matrix multiplyMatrix = Matrix.MultiplyMatrices(firstMultiplyMatrix, secondMultiplyMatrix);
        multiplyMatrix.PrintMatrix();
    }
}
