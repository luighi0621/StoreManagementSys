using Moq;
using NUnit.Framework;
using ProxyPattern.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class ProxyPatternTest
    {
        private Mock<ProxyPattern.Subjects.IMath> _math;
        private MathProxy _proxy;

        [SetUp]
        public void SetUp()
        {
            _math = new Mock<ProxyPattern.Subjects.IMath>();
            _math.Setup(x => x.Add(It.IsAny<double>(), It.IsAny<double>())).Returns((double x, double y) => { return x + y;  });
            _math.Setup(x => x.Sub(It.IsAny<double>(), It.IsAny<double>())).Returns((double x, double y) => { return x - y; });
            _math.Setup(x => x.Mul(It.IsAny<double>(), It.IsAny<double>())).Returns((double x, double y) => { return x * y; });
            _math.Setup(x => x.Div(It.IsAny<double>(), It.IsAny<double>())).Returns((double x, double y) => { return x / y; });
            _proxy = new MathProxy(_math.Object);
        }

        [Test, Category("Proxy")]
        public void AddValues()
        {
            double d1 = 2.5;
            double d2 = 3.6;
            var result = _proxy.Add(d1, d2);
            _math.Verify(p => p.Add(It.IsAny<double>(), It.IsAny<double>()));
            Assert.AreEqual(d1 + d2, result);
        }

        [Test, Category("Proxy")]
        public void SubstractValues()
        {
            double d2 = 2.5;
            double d1 = 3.6;
            var result = _proxy.Sub(d2, d1);
            _math.Verify(p => p.Sub(It.IsAny<double>(), It.IsAny<double>()));
            Assert.AreEqual(d2 - d1, result);
        }

        [Test, Category("Proxy")]
        public void MultValues()
        {
            double d1 = 2.5;
            double d2 = 3.5;
            var result = _proxy.Mul(d1, d2);
            _math.Verify(p => p.Mul(It.IsAny<double>(), It.IsAny<double>()));
            Assert.AreEqual(d1 * d2, result);
        }

        [Test, Category("Proxy")]
        public void DivValues()
        {
            double d1 = 2.5;
            double d2 = 3.6;
            var result = _proxy.Div(d1, d2);
            _math.Verify(p => p.Div(It.IsAny<double>(), It.IsAny<double>()));
            Assert.AreEqual(d1 / d2, result);
        }
    }
}
