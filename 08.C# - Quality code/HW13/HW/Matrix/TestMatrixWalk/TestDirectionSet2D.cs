using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixNamespace;

namespace TestMatrixWalk
{
    [TestClass]
    public class TestDirectionSet2D
    {
        [TestMethod]
        public void TestCreation()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCount()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(-1, directionsX, directionsY);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDirectionX()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1};
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDirectionY()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);
        }
    }
}
