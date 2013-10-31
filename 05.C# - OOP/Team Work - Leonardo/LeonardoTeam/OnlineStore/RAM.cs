using System;

namespace OnlineStore
{
    public class RAM:Memory
    {
        public RAM(string capacity, string type, string model, Brand brand, decimal price)
            : base(model, brand, price, capacity, type)
        {}
    }
}
