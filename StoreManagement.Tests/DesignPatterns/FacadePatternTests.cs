using FacadePattern;
using FacadePattern.SubSystems;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class FacadePatternTests
    {
        private Mock<IBank> _mockBank;
        private Mock<ICredit> _mockCredit;
        private Mock<ILoan> _mockLoan;
        private BNB _BNB;

        [SetUp]
        public void SetUp()
        {
            _mockBank = new Mock<IBank>();
            _mockBank.Setup(b => b.HasSufficientSavings(It.IsAny<Customer>(), It.IsAny<int>())).Returns(true);

            _mockLoan = new Mock<ILoan>();
            _mockLoan.Setup(l => l.HasNoBadLoans(It.IsAny<Customer>())).Returns(true);

            _mockCredit = new Mock<ICredit>();
            _mockCredit.Setup(c => c.HasGoodCredit(It.IsAny<Customer>())).Returns(true);

            _BNB = new BNB(_mockBank.Object, _mockLoan.Object, _mockCredit.Object);
        }

        [Test, Category("Facade")]
        public void CustomerAskForCredit()
        {
            Customer c = new Customer("Luis");
            var response = _BNB.IsElegible(c, 5000);
            _mockBank.Verify(b=> b.HasSufficientSavings(It.IsAny<Customer>(), It.IsAny<int>()));
            _mockLoan.Verify(l => l.HasNoBadLoans(It.IsAny<Customer>()));
            _mockCredit.Verify(cr=> cr.HasGoodCredit(It.IsAny<Customer>()));
            Assert.IsTrue(response);
        }

    }
}
