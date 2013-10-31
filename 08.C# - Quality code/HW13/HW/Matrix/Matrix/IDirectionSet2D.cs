namespace MatrixNamespace
{
    using System;

    public interface IDirectionSet2D
    {
        int Count { get; set; }

        int[] DirectionsX { get; set; }

        int[] DirectionsY { get; set; }
    }
}