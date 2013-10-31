using System;

namespace OnlineStore
{
    public abstract class Configuration:Product,ISellable
    {
        public Configuration(string model, Brand brand, decimal price)
            : base(model, brand, price)
        {} 
    }
}
