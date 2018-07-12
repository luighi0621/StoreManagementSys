using System;

namespace BadCodeSmells
{
    public class Loan
    {
        //Dispensable: Data Class
        public float Mount { get; private set; }
        public int Years { get; private set; }
        public DateTime Date { get; private set; }
        public float Feed { get; private set; }

        public Loan(float mount, DateTime date, float feed)
        {
            Mount = mount;
            Date = date;
            Years = date.Year - DateTime.Today.Year;
            Feed = feed;
        }
        public float Total
        {
            get
            {
                return Mount * Feed * Years;
            }
        }
    }
}
