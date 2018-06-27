using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityPattern.Handlers
{
    public class Director : Approver
    {
        public override ResultApprover ProcessRequest(Purchase purchase)
        {
            if(purchase.Amount < 10000.0) {
                Console.WriteLine("{0} approved request #{1}", this.GetType().Name, purchase.Number);
                return ResultApprover.DirectorApproved;
            }
            else if(successor != null)
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
