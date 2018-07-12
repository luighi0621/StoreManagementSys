using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.SubSystems
{
    public class Loan: ILoan
    {
        public bool HasNoBadLoans(Customer customer)
        {
            Console.WriteLine("Check loans for {0}", customer.Name);
            return true;
        }
    }
}
