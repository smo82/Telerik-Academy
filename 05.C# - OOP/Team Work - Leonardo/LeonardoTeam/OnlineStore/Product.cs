using System;

namespace OnlineStore
{
    public abstract class Product:IStorable
    {
        protected static int idcounter = 0;
        private decimal price;

        public decimal Price
        {
            get { return this.price; }
            set { price = value; }
        }
        private int id;

        public int Id
        {
            get { return this.id; }
            private set { id = value; }
        }
        
        private Brand brand;

        public Brand Brand
        {
            get { return this.brand; }
            set { brand = value; }
        }
               
        private string model = "";

        public string Model
        {
            get { return this.model; }
            set { model = value; }
        }

        //Initializes the "id" field of the object
        public void InitID ()
        {
            if (this.id == 0)
            {
                Product.idcounter++;
                this.Id = Product.idcounter;
            }
        }

        public Product(string model, Brand brand, decimal price)
        {
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            InitID();
        }

        public virtual decimal GetPrice()
        {
            return this.Price;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} - {3:c}", this.GetType().Name, this.Brand, this.Model, GetPrice());
        }
    }
}
