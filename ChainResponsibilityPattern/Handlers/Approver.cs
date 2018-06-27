using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityPattern.Handlers
{
    public abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract ResultApprover ProcessRequest(Purchase purchase);
    }

    public enum ResultApprover
    {
        DirectorApproved,
        ViceApproved,
        PresiApproved,
        NeedExecutiveMetting
    }
}
