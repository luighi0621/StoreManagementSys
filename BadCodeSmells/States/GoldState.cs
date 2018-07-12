namespace BadCodeSmells.States
{
    public class GoldState : State
    {
        public GoldState(int b, Account a) : base(b, a)
        {
            typeAccount = TypeAccount.GOLD;
            maxLoan = 10000;
        }
    }
}
