namespace BadCodeSmells.States
{
    public class SilverState : State
    {
        public SilverState(int b, Account a) : base(b, a)
        {
            typeAccount = TypeAccount.SILVER;
            maxLoan = 1000;
        }
    }
}
