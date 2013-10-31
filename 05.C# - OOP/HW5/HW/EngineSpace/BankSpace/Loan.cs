using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public class Loan : Account
    {
        public Loan(Customer pAccountCustomer, decimal pBalance, decimal pInterestRate)
            : base(pAccountCustomer, pBalance, pInterestRate)
        { }

        public override decimal CalcInterestRate(decimal numberOfMonths)
        {
            int monthsToSubtract = 0;
            if (this.AccountCustomer is Company)
                monthsToSubtract = 3;
            else if (this.AccountCustomer is Individual)
                monthsToSubtract = 2;

            if (monthsToSubtract >= numberOfMonths)
                return 0;
            else
                return (numberOfMonths - monthsToSubtract) * this.InterestRate;
        }
    }
}