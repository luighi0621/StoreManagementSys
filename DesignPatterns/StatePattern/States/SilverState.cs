using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    public class SilverState : State
    {
        public SilverState(State state)
            : this(state.Balance, state.Account)
        {

        }

        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.01;
            lowerLimit = 0.00;
            upperLimit = 1000.00;
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
            if(balance < lowerLimit)
            {
                account.State = new RedState(this);
            }
            else if(balance > upperLimit) {
                account.State = new GoldState(this);
            }
        }
    }
}
