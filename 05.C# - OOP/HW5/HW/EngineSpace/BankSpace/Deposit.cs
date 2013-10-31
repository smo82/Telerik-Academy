using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public class Deposit : Account
    {
        public Deposit (Customer pAccountCustomer, decimal pBalance, decimal pInterestRate)
			: base (pAccountCustomer, pBalance, pInterestRate)
		{}
		
		public virtual void WithDraw(decimal Amount) 
		{
			this.Balance -= Amount;
		}
		
		public override decimal CalcInterestRate(decimal numberOfMonths) 
		{
			if (this.Balance >=0 && this.Balance <=1000)
				return 0;
			else 
				return numberOfMonths * this.InterestRate;
		}
    }
}