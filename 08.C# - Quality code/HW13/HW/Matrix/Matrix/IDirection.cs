namespace MatrixNamespace
{
    using System;

    public interface IDirection
    {
        void GetDelta(out int deltaX, out int deltaY);

        void Increase();

        void Decrease();
    }
}