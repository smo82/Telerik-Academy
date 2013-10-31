using System;

namespace OnlineStore
{
    public class CPU:Parts
    {
        private string speed = "";

        public string Speed
        {
            get { return this.speed; }
            set { speed = value; }
        }
        public CPU(string speed, string model, Brand brand, decimal price)
            :base(model, brand, price)
        {
            this.Speed = speed;
        }
    }
}
