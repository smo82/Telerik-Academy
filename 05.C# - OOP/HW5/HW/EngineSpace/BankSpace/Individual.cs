using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public class Individual : Customer
    {
        public string LastName {get; private set;}

        public Individual(string pFirstName, string pLastName)
			: base(pFirstName)
		{
			this.LastName = pLastName;
		}
		
		public override string ToString()
        {
            return String.Format("{0} {1}", this.Name, this.LastName);
        }
    }
}