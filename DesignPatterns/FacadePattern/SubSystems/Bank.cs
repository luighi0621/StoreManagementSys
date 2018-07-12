using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.SubSystems
{
    public class Bank: IBank
    {
        public bool HasSufficientSavings(Customer customer, int amount)
        {
            Console.WriteLine("Check bank for {0}", customer.Name);
            return true;
        }
    }
}
