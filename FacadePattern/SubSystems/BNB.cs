using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.SubSystems
{
    public class BNB
    {
        private IBank _bank;
        private ILoan _loan;
        private ICredit _credit;

        public BNB()
        {
            _bank = new Bank();
            _loan = new Loan();
            _credit = new Credit();
        }

        public BNB(IBank bank, ILoan loan, ICredit credit)
        {
            _bank = bank;
            _loan = loan;
            _credit = credit;
        }

        public bool IsElegible(Customer customer, int amount)
        {
            Console.WriteLine("{0} applier for {1:C} loan\n", customer.Name, amount);

            bool elegible = true;
            if(!_bank.HasSufficientSavings(customer, amount))
            {
                elegible = false;
            } 
            else if (!_loan.HasNoBadLoans(customer))
            {
                elegible = false;
            }
            else if (!_credit.HasGoodCredit(customer))
            {
                elegible = false;
            }
            return elegible;
        }
    }
}
