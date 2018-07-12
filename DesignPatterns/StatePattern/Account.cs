using StatePattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Account
    {
        private State _state;
        private string _owner;
        public Account(string owner)
        {
            _owner = owner;
            _state = new SilverState(0.0, this);
        }

        public double Balance { get { return _state.Balance; } }
        public State State { get { return _state; } set { _state = value; } }

        private void PrintStatus()
        {
            Console.WriteLine("Balance =  {0:C}", this.Balance);
            Console.WriteLine("Status = {0}\n", State.GetType().Name);
        }

        public void Deposit(double amount)
        {
            _state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} ---", amount);
            PrintStatus();
        }

        public void WithDraw(double amount)
        {
            _state.WithDraw(amount);
            Console.WriteLine("WithDrew {0:C} --- ", amount);
            PrintStatus();
        }
        public void PayInterest()
        {
            _state.PayInterest();
            Console.WriteLine("Interest Paid ---");
            PrintStatus();
        }
        
    }
}
