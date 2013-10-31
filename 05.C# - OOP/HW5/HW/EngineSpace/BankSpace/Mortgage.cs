using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSpace
{
    public class Mortgage : Account
    {
        public Mortgage(Customer pAccountCustomer, decimal pBalance, decimal pInterestRate)
            : base(pAccountCustomer, pBalance, pInterestRate)
        { }

        public override decimal CalcInterestRate(decimal numberOfMonths)
        {
            decimal calcInterestRate = 0;
            if (this.AccountCustomer is Company)
            {
                if (numberOfMonths <= 6)
                    calcInterestRate = 0;
                else
                    calcInterestRate = (numberOfMonths - 6) * this.InterestRate;
            }
            else if (this.AccountCustomer is Individual)
            {
                if (numberOfMonths <= 12)
                    calcInterestRate = numberOfMonths * this.InterestRate / 2;
                else
                    calcInterestRate = 12 * this.InterestRate / 2 + (numberOfMonths - 12) * this.InterestRate;
            }

            return calcInterestRate;
        }
    }
}