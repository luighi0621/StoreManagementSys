using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.SubSystems
{
    public class Credit: ICredit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine("Check credit for {0}", customer.Name);
            return true;
        }
    }
}
