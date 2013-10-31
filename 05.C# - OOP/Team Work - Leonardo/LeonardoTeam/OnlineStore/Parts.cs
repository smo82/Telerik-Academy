using System;

namespace OnlineStore
{
    public abstract class Parts:Product
    {
        public Parts(string model,Brand brand,decimal price  )
            : base( model, brand, price )
        {}
    }
}
