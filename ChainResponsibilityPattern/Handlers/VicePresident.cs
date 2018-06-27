using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityPattern.Handlers
{
    public class VicePresident : Approver
    {
        public override ResultApprover ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request #{1}", this.GetType().Name, purchase.Number);
                return ResultApprover.ViceApproved;
            }
            else if (successor != null)
            {
                return successor.ProcessRequest(purchase);
            }
            else
            {
                return ResultApprover.NeedExecutiveMetting;
            }
        }
    }
}
