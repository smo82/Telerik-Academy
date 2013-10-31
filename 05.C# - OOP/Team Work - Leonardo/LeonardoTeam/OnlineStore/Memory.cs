using System;

namespace OnlineStore
{
    public class Memory:Parts
    {
        private string type = null;     //type of the memory: hard disk or SM 

        public string Type
        {
            get { return this.type; }
            set { type = value; }
        }

        public string Capacity { get; set; }

        public Memory(string model, Brand brand, decimal price, string capacity, string type)
            :base(model, brand, price)
        {
            this.Capacity = capacity;
            this.Type = type;            
        }
    }
}
