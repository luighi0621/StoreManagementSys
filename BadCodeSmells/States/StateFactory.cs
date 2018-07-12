namespace BadCodeSmells.States
{
    public static class StateFactory
    {
        //Organizing Data - Replace Type Code with State/Strategy
        public static State CreateAccount(int firstDeposit, Account account)
        {
            State created;
            if (firstDeposit > 10000)
            {
                created = new GoldState(firstDeposit, account);
            }
            else if (firstDeposit > 5000)
            {
                created = new SilverState(firstDeposit, account);
            }
            else
            {
                created = new BronzeState(firstDeposit, account);
            }

            return created;
        }
    }
}
