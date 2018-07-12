using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityPattern.Handlers
{
    public class President : Approver
    {
        public override ResultApprover ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request #{1}", this.GetType().Name, purchase.Number);
                return ResultApprover.PresiApproved;
            }
            else
            {
                Console.WriteLine("Request #{0} requires an executive meeting!", purchase.Number);
                return ResultApprover.NeedExecutiveMetting;
            }
        }
    }
}
