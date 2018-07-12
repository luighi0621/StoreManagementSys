using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    internal class RedState : State
    {
        private double _serviceFee;

        public RedState(State state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.00;
            lowerLimit = -100.00;
            upperLimit = 0.00;
            _serviceFee = 15.00;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        protected override void StateChangeCheck()
        {
            if(balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }

        public override void PayInterest()
        {
            Console.WriteLine("No interest paid");
        }

        public override void WithDraw(double amount)
        {
            amount = amount - _serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }
    }
}
