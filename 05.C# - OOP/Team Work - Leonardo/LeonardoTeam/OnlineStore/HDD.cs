using System;

namespace OnlineStore
{
    public class HDD:Memory
    {
        private string speed = "";

        public string Speed
        {
            get { return this.speed; }
            set { speed = value; }
        }
        public HDD(string model, Brand brand, decimal price, string speed, string capacity, string type)
            : base(model, brand, price, capacity, type)
        {
            this.speed = speed;
        }
    }
}
