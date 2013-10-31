using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixNamespace;

namespace TestMatrixWalk
{
    [TestClass]
    public class TestMatrixWalkEngline
    {
        [TestMethod]
        public void TestWalkMatrixPath()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            int pathLenght = MatrixWalkEngine.WalkMatrixPath(matrix, 0, 0, 1);
            Assert.AreEqual(pathLenght, 22);

            int[,] resultMatrix =
                {
                    {1, 13, 14, 15, 16},
                    {12, 2, 21, 22, 17},
                    {11, 0, 3, 20, 18},
                    {10, 0, 0, 4, 19},
                    {9, 8, 7, 6, 5}
                };

            for (int i = 0; i < matrixRang; i++)
            {
                for (int j = 0; j < matrixRang; j++)
                {
                    Assert.AreEqual(matrix.Grid[i,j], resultMatrix[i,j]);
                }
            }
        }

        [TestMethod]
        public void TestWalkEntireMatrix()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            MatrixWalkEngine.WalkEntireMatrix(matrix);

            int[,] resultMatrix =
                {
                    {1, 13, 14, 15, 16},
                    {12, 2, 21, 22, 17},
                    {11, 23, 3, 20, 18},
                    {10, 25, 24, 4, 19},
                    {9, 8, 7, 6, 5}
                };

            for (int i = 0; i < matrixRang; i++)
            {
                for (int j = 0; j < matrixRang; j++)
                {
                    Assert.AreEqual(matrix.Grid[i, j], resultMatrix[i, j]);
                }
            }
        }
    }
}
