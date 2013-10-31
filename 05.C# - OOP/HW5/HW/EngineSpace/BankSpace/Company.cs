using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public class Company : Customer
    {
        public string Type {get; private set;}

        public Company(string pName, string pType)
			: base(pName)
		{
			this.Type = pType;
		}
		
		public override string ToString()
        {
            return String.Format("{0} {1}", this.Name, this.Type);
        }
    }
}