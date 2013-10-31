using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Data.Model
{
    public class AtmDAL
    {
        public static void LogSuccessfulTransaction(string cardNumber, DateTime transactionDate, decimal amount)
        {
            /*
             * Task03
             * We again use Repeatable read because we don't want someone to change the CardNumber while we are creating a new trasnaction history log for that card number
             */

            TransactionScope tran = new TransactionScope(
               TransactionScopeOption.Required,
                   new TransactionOptions()
                   {
                       IsolationLevel = IsolationLevel.RepeatableRead
                   });
            using (tran)
            {
                using (ATMEntitiesModel context = new ATMEntitiesModel())
                {
                    TransactionsHistory newLogEntry = new TransactionsHistory() { 
                        CardNumber = cardNumber,
                        TransactionDate = transactionDate,
                        Amount = amount
                    };

                    context.TransactionsHistories.Add(newLogEntry);
                    context.SaveChanges();
                }

                tran.Complete();
            }
        }
        public static decimal RetreiveFunds(string cardNumber, string cardPin, decimal amount)
        {
            decimal remainingAmount = 0;
            TransactionScope tran = new TransactionScope(
               TransactionScopeOption.Required,
                   new TransactionOptions()
                   {
                       IsolationLevel = IsolationLevel.RepeatableRead
                   });
            using (tran)
            {
                using (ATMEntitiesModel context = new ATMEntitiesModel())
                {
                    var cardAccount = context.CardAccounts.FirstOrDefault(c => c.CardNumber == cardNumber && c.CardPIN == cardPin);

                    if (cardAccount == null)
                    {
                        throw new InvalidOperationException("Invalid Card Number of Card Pin");
                    }
                    decimal currentCardAmount = cardAccount.CardCash;

                    if (currentCardAmount < amount)
                    {
                        throw new InvalidOperationException("Insufficient Card Amount");
                    }

                    remainingAmount = cardAccount.CardCash - amount;
                    cardAccount.CardCash = remainingAmount;
                    context.SaveChanges();
                }

                tran.Complete();
            }

            return remainingAmount;
        }
    }
}
