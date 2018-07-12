using BadCodeSmells;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StoreManagement.Tests.Refactoring
{
    [TestClass]
    public class BadCodeTests
    {
        [TestMethod]
        public void CheckAvailabilityReturnsFalseAccountNotExists()
        {
            bool response = Program.ChecksIfAvailable(5000, "Jose", BadCodeSmells.States.TypeAccount.NONE, new DateTime(2020, 12, 25), 0.15f);
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void CheckAvailabilityReturnsFalseAccountNotExistsRefactoring()
        {
            Account jose = new Account("Jose");
            Loan loan = new Loan(5000, new DateTime(2020, 12, 25), 0.15f);
            bool response = Program.ChecksIfAvailable(loan, jose);
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void CheckAvailabilityReturnsFalseAccountExists()
        {
            bool response = Program.ChecksIfAvailable(5000, "Jose", BadCodeSmells.States.TypeAccount.BRONZE, new DateTime(2020, 12, 25), 0.15f);
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void CheckAvailabilityReturnsFalseAccountExistsRefactoring()
        {
            Account jose = new Account("Jose", 1500);
            Loan loan = new Loan(5000, new DateTime(2020, 12, 25), 0.15f);
            bool response = Program.ChecksIfAvailable(loan, jose);
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void CheckAvailabilityReturnsTrue()
        {
            bool response = Program.ChecksIfAvailable(5000, "Jorge", BadCodeSmells.States.TypeAccount.GOLD, new DateTime(2020, 12, 25), 0.15f);
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void CheckAvailabilityReturnsTrueRefactoring()
        {
            Account jorge = new Account("Jorge", 10500);
            Loan loan = new Loan(5000, new DateTime(2020, 12, 25), 0.15f);
            bool response = Program.ChecksIfAvailable(loan, jorge);
            Assert.IsTrue(response);
        }
    }
}
