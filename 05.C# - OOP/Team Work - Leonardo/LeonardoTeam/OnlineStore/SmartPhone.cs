using System;

namespace OnlineStore
{
    public class SmartPhone :Configuration
    {
        public SmartPhone(string model, Brand brand, decimal price)
            : base(model, brand, price)
        {}
    }
}
