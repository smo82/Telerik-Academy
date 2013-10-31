using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixNamespace;

namespace TestMatrixWalk
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void TestMatrixCreation()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            Matrix matrix = new Matrix(5, directionSet);
        }

        [TestMethod]
        public void TestMatrixIsValidEmptyCell()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            int testValue = 2;

            for (int i = 0; i < matrixRang; i++)
            {
                matrix[i, 0] = testValue;
            }

            bool fullCellCheckResult = matrix.IsValidEmptyCell(0, 0);
            Assert.IsFalse(fullCellCheckResult);

            bool emptyCellCheckResult = matrix.IsValidEmptyCell(0, 3);
            Assert.IsTrue(emptyCellCheckResult);

            bool incorrectIndexCell = matrix.IsValidEmptyCell(0, 6);
            Assert.IsFalse(incorrectIndexCell);
        }

        [TestMethod]
        public void TestMatrixIsIsChangeDirectionPossible()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            int testValue = 2;

            for (int i = 0; i < matrixRang; i++)
            {
                matrix[i, 0] = testValue;
            }

            bool possibleChangeDirection = matrix.IsChangeDirectionPossible(1, 0);
            Assert.IsTrue(possibleChangeDirection);

            for (int i = 0; i < matrixRang; i++)
            {
                for (int j = 0; j < matrixRang; j++)
                {
                    matrix[i, j] = testValue;
                }
            }

            bool impossibleChangeDirection = matrix.IsValidEmptyCell(1, 0);
            Assert.IsFalse(impossibleChangeDirection);
        }

        [TestMethod]
        public void TestMatrixFindEmptyCell()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            int testValue = 2;

            for (int i = 0; i < matrixRang; i++)
            {
                matrix[i, 0] = testValue;
            }

            int indexX;
            int indexY;
            bool foundEmptyCell = matrix.FindEmptyCell(out indexX, out indexY);
            Assert.IsTrue(foundEmptyCell);
            Assert.AreEqual(indexX, 0);
            Assert.AreEqual(indexY, 1);

            for (int i = 0; i < matrixRang; i++)
            {
                for (int j = 0; j < matrixRang; j++)
                {
                    matrix[i, j] = testValue;
                }
            }

            foundEmptyCell = matrix.FindEmptyCell(out indexX, out indexY);
            Assert.IsFalse(foundEmptyCell);
            Assert.AreEqual(indexX, -1);
            Assert.AreEqual(indexY, -1);
        }

        [TestMethod]
        public void TestMatrixIndex()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            int testValue = 2;
            matrix[2, 2] = testValue;
            int resultTestValue = matrix[2, 2];

            Assert.AreEqual(resultTestValue, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMatrixIndexException()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            int matrixRang = 5;
            Matrix matrix = new Matrix(matrixRang, directionSet);

            int testValue = 2;
            matrix[20, 2] = testValue;
        }
    }
}
