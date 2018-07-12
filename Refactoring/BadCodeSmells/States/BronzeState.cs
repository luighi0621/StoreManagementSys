namespace BadCodeSmells.States
{
    public class BronzeState : State
    {
        // Dealing with Generalisation - Pull Up Constructor Body
        public BronzeState(int b, Account a) : base(b, a)
        {
            typeAccount = TypeAccount.BRONZE;
            maxLoan = 1000;
        }
    }
}
