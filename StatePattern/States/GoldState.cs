using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    internal class GoldState : State
    {
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.05;
            lowerLimit = 1000.00;
            upperLimit = 10000000.00;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        public override void WithDraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        protected override void StateChangeCheck()
        {
            if (balance < 0)
            {
                account.State = new RedState(this);
            }else if(balance < lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }
}
