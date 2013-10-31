using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public abstract class Customer
    {
        public string Name {get; protected set;}

        public Customer(string pName)
		{
			this.Name = pName;
		}
		
		public override string ToString()
        {
            return String.Format("{0}", this.Name);
        }
    }
}