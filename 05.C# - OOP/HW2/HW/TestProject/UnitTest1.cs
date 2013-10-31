using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collection3D;
using Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        //Point3D, Calc3D, Path & PathStorage test
        [TestMethod]
        public void TestMethod1()
        {
            //{{1, 2, 2}, {2, 3, 6}, {0, 3, 4}}
            Path testPath = PathStorage.LoadPath(@"..\..\input.txt");
            testPath.AddPoint(1, 2, 2);
            testPath.AddPath(new int[2, 3] {{2,3,6}, {0,3,4}});

            double[] distanceToZero = new double[testPath.Count];
            Point3D[] pathPoints = testPath.GetPath();
            double[] resultsDistance = {3.0, 7.0, 5.0, 3.0, 7.0, 5.0};

            for (int i = 0; i < testPath.Count; i++)
            {
                distanceToZero[i] = Calc3D.Distance(Point3D.ZeroPoint, pathPoints[i]);
                Assert.AreEqual(resultsDistance[i], distanceToZero[i]);
            }

            PathStorage.SavePath(@"..\..\output.txt", testPath);
        }

        //GenericList test
        [TestMethod]
        public void TestMethod2()
        {
            //We create a Matrix<int> array of 1 element
            Matrix<int> [] matrixArr = new Matrix<int> [1] {new Matrix<int>( new int [2,2] {{1,1}, {2,2}})};

            //The created GenericList is with capacity - 2 elements
            GenericList<Matrix<int>> matrixGenericList = new GenericList<Matrix<int>>(matrixArr);

            //We add new element to the Generic list and it is full
            matrixGenericList.AddElement(new Matrix<int>(new int[2, 2] { { 3, 3 }, { 4, 4 } }));

            //We add one more new element and the Generic list should double its capacity
            matrixGenericList.AddElement(new Matrix<int>(new int[2, 2] { { 5, 5 }, { 6, 6 } }));

            //We remove the middle element
            matrixGenericList.RemoveElement(1);

            //We insert one new element in the middle
            matrixGenericList.InsertElement(1, new Matrix<int>(new int[2, 2] { { 7, 7 }, { 8, 8 } }));

            //Find the index of the matrix { { 7, 7 }, { 8, 8 } }
            int indexSearch;
            if (matrixGenericList.FindElementIndex(new Matrix<int>(new int[2, 2] { { 7, 7 }, { 8, 8 } }), out indexSearch))
            {
                Assert.AreEqual(1, indexSearch);
            }                

            //Find min matrix
            Matrix<int> minMatrix = matrixGenericList.Min();

            //Find max matrix
            Matrix<int> maxMatrix = matrixGenericList.Max();

            //Convert the list to string
            string genericListToString = matrixGenericList.ToString();


            //Check matrix not Zero and use GenericList index
            bool zeroMatrix = matrixGenericList[0] ? true : false;
            Assert.AreEqual(true, zeroMatrix);
            
            //Check Zero matrix
            zeroMatrix = new Matrix<int>(new int[1, 1] { { 0 } }) ? true : false;
            Assert.AreEqual(false, zeroMatrix);

            //Sum 2 matrixes
            matrixGenericList[0] = matrixGenericList[0] + matrixGenericList[1];

            //Subtract 2 matrixes
            matrixGenericList[0] = matrixGenericList[0] - matrixGenericList[1];

            //Multiply 2 matrixes
            matrixGenericList[0] = matrixGenericList[0] * matrixGenericList[1];
        }
    }
}
