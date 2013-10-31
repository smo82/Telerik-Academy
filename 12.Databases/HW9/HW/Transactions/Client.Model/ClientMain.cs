/*
 * Task02
 * Using transactions write a method which retrieves some money (for example $200) from certain account. 
 * The retrieval is successful when the following sequence of sub-operations is completed successfully:
 * A query checks if the given CardPIN and CardNumber are valid.
 * The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
 * The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
 */

/*
 * NOTE: YOU CAN FIND THE DATABASE BACKUP IN THE SOLUTION FOLDER
 */

using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class ClientMain
    {
        /*
         * Q: Why does the isolation level need to be set to “repeatable read”?
         * A: Because if we don't lock the objects we are working with someone else could connect to the DB and change the card number or the amount for example
         */

        static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Please enter the Card Number:");
            string cardNumber = Console.ReadLine();
            
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Please enter the Card Pin:");
            string cardPin = Console.ReadLine();
            
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Please enter the amount you want to withdraw:");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                // Task02
                decimal remainingAmount = AtmDAL.RetreiveFunds(cardNumber, cardPin, amount);

                Console.WriteLine("The remaining amount is: {0}", remainingAmount);

                // Task03
                AtmDAL.LogSuccessfulTransaction(cardNumber, DateTime.Now, amount);
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("The transaction was logged!");
            }
            catch(InvalidOperationException e){
                Console.WriteLine("Invalid operation: {0}", e.Message);
            }
        }
    }
}
