using BadCodeSmells.States;

namespace BadCodeSmells
{
    public class Account
    {
        private State _state;
        private double balance = 0;
        private string _name;
        public Account(string n, int firstDeposit = 0)
        {
            _name = n;
            balance = firstDeposit;
            // Simplifying Method Calls - Replace Constructor with Factory Method
            _state = StateFactory.CreateAccount(firstDeposit, this);
        }
        public string Name { get { return _name; } }
        // Dealing with Generalisation - Replace Inheritance with Delegation
        public int MaxLoan { get { return _state.MaxLoan; } }
    }
}
