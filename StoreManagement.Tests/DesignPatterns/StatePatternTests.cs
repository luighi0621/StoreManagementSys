using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.States;
using StatePattern;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class StatePatternTests
    {
        [Test, Category("State")]
        [TestCase(500)]
        public void SilverState(int deposit)
        {
            Account ac = new Account("Luis");
            string accountType = "SilverState";
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.IsTrue(ac.Balance == 0);

            ac.Deposit(deposit);
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.AreEqual(ac.Balance, 500);
        }

        [Test, Category("State")]
        [TestCase(50)]
        public void SilverStatePayInteres(int deposit)
        {
            Account ac = new Account("Luis");
            string accountType = "SilverState";
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.IsTrue(ac.Balance == 0);

            ac.Deposit(deposit);
            ac.PayInterest();
            Assert.Greater(ac.Balance, deposit);
        }

        [Test, Category("State")]
        [TestCase(1001)]
        public void SilverStateToGoldState(int deposit)
        {
            Account ac = new Account("Luis");
            string accountType = "SilverState";
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.IsTrue(ac.Balance == 0);

            ac.Deposit(deposit);
            if(deposit> 1000)
            {
                accountType = "GoldState";
            }
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.AreEqual(ac.Balance, 1001);
        }

        [Test, Category("State")]
        [TestCase(70)]
        public void SilverStateToRedState(int withdraw)
        {
            Account ac = new Account("Luis");
            string accountType = "SilverState";
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.IsTrue(ac.Balance == 0);

            ac.WithDraw(withdraw);
            Assert.IsTrue(ac.State.GetType().Name == "RedState");
            ac.PayInterest();
            Assert.Less(ac.Balance, withdraw);
        }

        [Test, Category("State")]
        [TestCase(new int[] { 50, 1000, -1060 })]
        public void SilverStateToRedState(int[] operations)
        {
            Account ac = new Account("Luis");
            string accountType = "SilverState";
            Assert.IsTrue(ac.State.GetType().Name == accountType);
            Assert.IsTrue(ac.Balance == 0);

            foreach (var money in operations)
            {
                if (money > 0)
                {
                    ac.Deposit(money);
                }
                else
                {
                    ac.WithDraw(Math.Abs(money));
                }
            }
            Assert.Less(ac.Balance, 0);
            Assert.AreEqual(ac.State.GetType().Name, "RedState");
        }
    }
}
