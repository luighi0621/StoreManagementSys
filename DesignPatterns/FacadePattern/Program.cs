using FacadePattern.SubSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BNB banco = new BNB();

            Customer customer = new Customer("Luis");
            bool elegible = banco.IsElegible(customer, 125000);

            Console.WriteLine("\n{0} has been {1}", customer.Name, elegible ?  "Approved": "Rejected");
            Console.ReadKey();
        }
    }
}
