namespace BadCodeSmells.States
{
    public abstract class State
    {
        //Dispensable: Data Class
        protected Account account;
        protected double balance;
        protected int maxLoan;
        protected TypeAccount typeAccount;
        public State(int balance, Account c)
        {
            this.balance = balance;
            account = c;
        }
        //Organizing Data - Self Encapsulate Field
        //Organizing Data - Encapsulate Field
        public Account Account { get { return account; } }
        public int MaxLoan { get { return maxLoan; } }
        public double Balance { get { return balance; } }
        public TypeAccount TypeAccount { get { return typeAccount; } }
    }

    public enum TypeAccount
    {
        GOLD,
        SILVER,
        BRONZE,
        NONE
    }
    public enum LoanStatus
    {
        Accepted,
        Denied,
        InProgress
    }
}
