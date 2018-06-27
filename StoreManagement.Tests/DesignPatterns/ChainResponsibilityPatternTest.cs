using ChainResponsibilityPattern;
using ChainResponsibilityPattern.Handlers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class ChainResponsibilityPatternTest
    {
        private Approver _director;
        private Mock<Director> _dir;
        private Approver _president;
        private Mock<President> _presi;
        private Approver _vicepresident;
        private Mock<VicePresident> _vice;

        [SetUp]
        public void SetUp()
        {
            _dir = new Mock<Director>();
            _dir.CallBase = true;
            _director = _dir.Object;

            _vice = new Mock<VicePresident>();
            _vice.CallBase = true;
            _vicepresident = _vice.Object;

            _presi = new Mock<President>();
            _presi.CallBase = true;
            _president = _presi.Object;

            _director.SetSuccessor(_vicepresident);
            _vicepresident.SetSuccessor(_president);
        }
        [Test, Category("ChainResponsibility")]
        public void DirectorApproves()
        {
            Purchase purchase = new Purchase(1234, 350.00, "TestA");
            var result = _director.ProcessRequest(purchase);
            _vice.VerifyNoOtherCalls();
            _presi.VerifyNoOtherCalls();
            Assert.AreEqual(ResultApprover.DirectorApproved, result);
        }

        [Test, Category("ChainResponsibility")]
        public void ViceApproves()
        {
            Purchase purchase = new Purchase(1234, 15000.00, "TestA");
            var result = _director.ProcessRequest(purchase);
            _vice.Verify(v => v.ProcessRequest(purchase));
            _presi.VerifyNoOtherCalls();
            Assert.AreEqual(ResultApprover.ViceApproved, result);
        }

        [Test, Category("ChainResponsibility")]
        public void PresiApproves()
        {
            Purchase purchase = new Purchase(1234, 35000.00, "TestA");
            var result = _director.ProcessRequest(purchase);
            _vice.Verify(v => v.ProcessRequest(purchase));
            _presi.Verify(p => p.ProcessRequest(purchase));
            Assert.AreEqual(ResultApprover.PresiApproved, result);
        }

        [Test, Category("ChainResponsibility")]
        public void NeedMeetingToApprove()
        {
            Purchase purchase = new Purchase(1234, 100001.00, "TestA");
            var result = _director.ProcessRequest(purchase);
            _vice.Verify(v => v.ProcessRequest(purchase));
            _presi.Verify(p => p.ProcessRequest(purchase));
            Assert.AreEqual(ResultApprover.NeedExecutiveMetting, result);
        }
    }
}
