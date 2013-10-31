namespace MatrixNamespace
{
    using System;

    public class Direction2D : IDirection
    {
        private IDirectionSet2D directionSet;
        private int number = 0;

        public Direction2D(IDirectionSet2D directionSet)
        {
            this.directionSet = directionSet;
        }

        public Direction2D(IDirectionSet2D directionSet, int direction)
            : this(directionSet)
        {
            this.Number = direction;
        }

        public int Number
        {
            get { return this.number; }

            set
            {
                if ((value < 0) || (value >= this.directionSet.Count))
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The direction number should be between 0 and {0}", this.directionSet.Count));
                }

                this.number = value;
            }
        }

        public void GetDelta(out int deltaX, out int deltaY)
        {
            deltaX = this.directionSet.DirectionsX[this.Number];
            deltaY = this.directionSet.DirectionsY[this.Number];
        }

        public void Increase()
        {
            int newNumber = this.Number + 1;
            if (newNumber == this.directionSet.Count)
            {
                newNumber = 0;
            }

            this.Number = newNumber;
        }

        public void Decrease()
        {
            this.Number--;
            if (this.Number == 0)
            {
                this.Number = this.directionSet.Count - 1;
            }
        }
    }
}