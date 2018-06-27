using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("Luis Choque");

            account.Deposit(500.00);
            account.Deposit(300.00);
            account.Deposit(550.00);
            account.PayInterest();
            account.WithDraw(2000.00);
            account.WithDraw(1100.00);

            Console.ReadKey();
        }
    }
}
