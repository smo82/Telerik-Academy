using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixNamespace;

namespace TestMatrixWalk
{
    [TestClass]
    public class TestDirection2D
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNumber()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            Direction2D direction = new Direction2D(directionSet);

            direction.Number = 10;
        }

        [TestMethod]
        public void TestGetDeltaIncreaseDecrease()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            DirectionSet2D directionSet = new DirectionSet2D(8, directionsX, directionsY);

            Direction2D direction = new Direction2D(directionSet);

            int deltaX;
            int deltaY;
            direction.GetDelta(out deltaX, out deltaY);
            Assert.AreEqual(deltaX, 1);
            Assert.AreEqual(deltaY, 1);

            direction.Increase();
            direction.Increase();

            direction.GetDelta(out deltaX, out deltaY);
            Assert.AreEqual(deltaX, 1);
            Assert.AreEqual(deltaY, -1);

            direction.Decrease();

            direction.GetDelta(out deltaX, out deltaY);
            Assert.AreEqual(deltaX, 1);
            Assert.AreEqual(deltaY, 0);
        }
    }
}
