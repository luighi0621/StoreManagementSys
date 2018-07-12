using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.SubSystems
{
    public interface ILoan
    {
        bool HasNoBadLoans(Customer customer);
    }
}
