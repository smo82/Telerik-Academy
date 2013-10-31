using System;

namespace BankSpace
{
    interface IAccountable
    {
        void Deposit(decimal Amount);

        decimal CalcInterestRate(decimal numberOfMonths);
    }
}