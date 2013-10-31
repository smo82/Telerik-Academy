namespace MatrixNamespace
{
    using System;

    public class DirectionSet2D : IDirectionSet2D
    {
        private int count = 0;
        private int[] directionsX;
        private int[] directionsY;

        public DirectionSet2D(int count, int[] directionsX, int[] directionsY)
        {
            this.Count = count;
            this.DirectionsX = directionsX;
            this.DirectionsY = directionsY;
        }

        public int Count
        {
            get { return this.count; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The directions set count should be bigger or equal to 0");
                }

                this.count = value;
            }
        }

        public int[] DirectionsX
        {
            get { return this.directionsX; }

            set
            {
                if (value.Length != this.Count)
                {
                    throw new ArgumentException(
                        string.Format("The number of directions should be equal to the set count: {0}", this.Count));
                }

                this.directionsX = value;
            }
        }

        public int[] DirectionsY
        {
            get { return this.directionsY; }

            set
            {
                if (value.Length != this.Count)
                {
                    throw new ArgumentException(
                        string.Format("The number of directions should be equal to the set count: {0}", this.Count));
                }

                this.directionsY = value;
            }
        }
    }
}