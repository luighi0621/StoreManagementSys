using BadCodeSmells.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCodeSmells
{
    public class Program
    {
        private static string[] accounts = new string[] { "Maria", "Pedro", "Jorge" };

        static void Main(string[] args)
        {
        }

        //BLOATERS: Long list parameters: More than three parameters
        //BLOATERS: Long method: More than three parameters
        //BLOATERS: Primitive Obsession: 
        //Moving Features between Objects - Extract Class
        public static bool ChecksIfAvailable(int mountLoan, string account, TypeAccount typeAccount, DateTime endPaid, float feed)
        {
            bool accountExists = false;
            //Object-Orientation Abusers - Temporary Field
            float total = 0;
            float fby = 0;
            int years = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (string.Compare(accounts[i], account, true) == 0)
                {
                    accountExists = true;
                    // Simplifying Conditional Expressions:Remove Control Flag
                    i = accounts.Length;
                }
            }
            int mountMaxToLoad = 0;
            if (accountExists)
            {
                // verify max loan according type account 
                // Dispensables - Comments
                // Object - Orientation Abusers: Switch Statements
                // Simplifying Conditional Expressions - Decompose Conditional
                switch (typeAccount)
                {
                    case TypeAccount.GOLD:
                        mountMaxToLoad = 10000;
                        break;
                    case TypeAccount.SILVER:
                        mountMaxToLoad = 5000;
                        break;
                    case TypeAccount.BRONZE:
                        mountMaxToLoad = 1000;
                        break;
                    default:
                        mountMaxToLoad = 500;
                        break;
                }
                if (mountLoan < mountMaxToLoad)
                {
                    //Dispensable-comments
                    // get number of years
                    years = endPaid.Year - DateTime.Today.Year;
                    // feed by years
                    fby = (feed * mountLoan) * years;
                    total = fby + mountLoan;
                    Console.WriteLine(Constants.LoanMessage, LoanStatus.Accepted.ToString(), account);
                    Console.WriteLine(Constants.LoanDetail, account, total, years, feed);
                    return true;
                }
                else
                {
                    //Dispensable: duplicate code
                    Console.WriteLine(Constants.LoanMessage, LoanStatus.Denied.ToString(), account);
                    return false;
                }

            }
            Console.WriteLine(Constants.LoanMessage, LoanStatus.Denied.ToString(), account);
            return false;
        }

        //Composing methods - replace method with object method
        //replace dava value with object
        //encapsule field
        // Simplifying Method Calls - Introduce Parameter Object
        public static bool ChecksIfAvailable(Loan loan, Account account)
        {
            double maxLoan = 0;
            //rename Method // Composing Methods - Extract Variable
            bool existsAccount = CheckAccount(account, ref maxLoan);
            // Extract Method
            // Simplifying Conditional Expressions - Replace Nested Conditional with Guard Clauses
            if (!existsAccount) return false;
            //Simplifying Conditional Expressions - Consolidate Duplicate Conditional Fragments
            Print(account.Name, loan, loan.Mount < maxLoan);
            //Simplifying Conditional Expressions - Remove Control Flag
            return loan.Mount < maxLoan;
        }
        //Composing methods - extract method
        private static void Print(string name, Loan l, bool accepted)
        {
            Console.WriteLine(Constants.LoanMessage, name, accepted ? LoanStatus.Accepted : LoanStatus.Denied);
            if (accepted)
            {
                //Organizing Data - Replace Data Value with Object
                Console.WriteLine(Constants.LoanDetail, name, l.Total, l.Years, l.Feed);
            }
        }
        //Composing methods - extract method
        private static bool CheckAccount(Account a, ref double MaxLoan)
        {
            foreach (string account in accounts)
            {
                if (string.Compare(a.Name, account, true) == 0)
                {
                    MaxLoan = a.MaxLoan;
                    return true;
                }
            }
            return false;
        }
        #region


    }
    #endregion
}
