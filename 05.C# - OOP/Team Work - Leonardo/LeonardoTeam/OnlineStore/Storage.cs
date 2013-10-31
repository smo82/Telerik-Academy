using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public class OutOfStorageEventArgs : EventArgs
    {
        public int ProductId { get; private set; }
        public int RemainingQuantity { get; private set; }

        public OutOfStorageEventArgs(int pProductId, int pRemainingQuantity)
        {
            this.ProductId = pProductId;
            this.RemainingQuantity = pRemainingQuantity;
        }
    }

    public delegate void OutOfStorageEventHandler(object sender, OutOfStorageEventArgs e);

    public class Storage
    {
        public event OutOfStorageEventHandler OutOfStorageEvent;

        public string Name { get; private set; }
        public string Address { get; private set; }
        private Dictionary<int, int> stock;

        public Storage (string pName, string pAddress)
        {
            this.Name = pName;
            this.Address = pAddress;
            this.stock = new Dictionary<int, int>();
        }

        //The method that raises the OutOfStorageEvent
        protected void RaiseOutOfStorageEvent(OutOfStorageEventArgs e)
        {
            OutOfStorageEventHandler handler = OutOfStorageEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Adds new stock of a given product
        public void AddStock (int productId, int productQuantity)
        {
            if (this.stock.ContainsKey(productId))
            {
                this.stock[productId] += productQuantity;
            }
            else
                this.stock.Add(productId, productQuantity);
        }

        //Gets the available stock of a given product
        public int GetStock (int productId)
        {
            if (this.stock.ContainsKey(productId))
                return stock[productId];
            else
                return 0;            
        }

        //Removes a given quantity of the product from the stock and returns the quantity
        //that remains unfulfilled. If there is enough stock of the product, the method returns 0.
        public int ExtractStock(int productId, int productQuantity)
        {
            int remainingQuantity = productQuantity;
            if (this.stock.ContainsKey(productId))
            {
                var test = this.stock[productId];
                if (remainingQuantity >= this.stock[productId])
                {
                    remainingQuantity -= this.stock[productId];
                    this.stock.Remove(productId);
                    RaiseOutOfStorageEvent(new OutOfStorageEventArgs(productId, remainingQuantity));
                }
                else
                {
                    remainingQuantity = 0;
                    this.stock[productId] -= productQuantity;
                }
            }
            return remainingQuantity;
        }
    }
}
