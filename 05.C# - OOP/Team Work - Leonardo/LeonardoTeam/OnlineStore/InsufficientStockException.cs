using System;

namespace OnlineStore
{
    class InsufficientStockException<T>: Exception
    {
/*  Define a class InsufficientStockException<T> that holds information about an error condition
    related to insufficient quantity of a requested item in the warehouse.   */

        private const string Message = "Insufficient/not available quantity";

        public T ProductId { get; private set; }
        public T Quantity { get; private set; }

        public InsufficientStockException(T productId, T quantity, Exception innerException = null)
            : base(Message, innerException)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }
    }
}
