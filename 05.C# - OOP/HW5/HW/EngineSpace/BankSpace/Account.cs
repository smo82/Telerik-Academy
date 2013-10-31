using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public abstract class Account : IAccountable
    {
        public decimal Balance {get; protected set;}
		public decimal InterestRate {get; protected set;}
		public Customer AccountCustomer {get; protected set;}
		
		public Account (Customer pAccountCustomer, decimal pBalance, decimal pInterestRate)
		{
			this.AccountCustomer = pAccountCustomer;
			this.Balance = pBalance;
			this.InterestRate = pInterestRate;
		}
		
		public virtual void Deposit(decimal Amount) 
		{
			this.Balance += Amount;
		}

        public virtual decimal CalcInterestRate(decimal numberOfMonths) 
		{
			return numberOfMonths * this.InterestRate;
		}
		
		public override string ToString()
        {
            return String.Format("{0} - {1} ({2})", this.AccountCustomer, this.Balance, this.InterestRate);
        }
    }
}