using Moq;
using NUnit.Framework;
using ServiceLocatorPattern;
using ServiceLocatorPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture, Category("ServiceLocator")]
    public class ServiceLocatorPatternTests
    {
        private Mock<IMotoDelivery> motoDelivery;
        private Mock<ICarDelivery> carDelivery;
        private Mock<IWalkDelivery> walkDelivery;

        [SetUp]
        public void SetUp() {
            motoDelivery = new Mock<IMotoDelivery>();
            motoDelivery.Setup(m => m.DeliveryPackage()).Returns("Message");

            carDelivery = new Mock<ICarDelivery>();
            carDelivery.Setup(c => c.DeliveryPackage()).Returns("Message");

            walkDelivery = new Mock<IWalkDelivery>();
            walkDelivery.Setup(w => w.DeliveryPackage()).Returns("Message").Verifiable();
        }

        [Test, Order(1)]
        public void ShouldStartWithNoServices()
        {
            Assert.AreEqual(0, ServiceLocator.Instance.Count);
        }

        [Test, Order(1)]
        public void ShouldThrowExceptionBecauseNoServicesRegistered()
        {
            var ex = Assert.Throws<ApplicationException>(() => { ServiceLocator.Instance.GetService<ICarDelivery>(); });
            Assert.AreEqual("The requested service is not registered.", ex.Message);
            Assert.AreEqual(typeof(KeyNotFoundException), ex.InnerException.GetType());
        }

        [Test, Order(2)]
        public void ShouldRegisterServices()
        {
            ServiceLocator.Instance.RegisterService(motoDelivery.Object);

            ServiceLocator.Instance.RegisterService(carDelivery.Object);

            ServiceLocator.Instance.RegisterService(walkDelivery.Object);

            Assert.Greater(ServiceLocator.Instance.Count, 0);
        }

        [Test]
        public void ShouldReturnCarDelivery()
        {
            var serviceTest = ServiceLocator.Instance.GetService<ICarDelivery>();
            Assert.IsNotNull(serviceTest);
            Assert.IsTrue(serviceTest is ICarDelivery);
        }

        [Test]
        public void ShouldReturnMotoDelivery()
        {
            var serviceTest = ServiceLocator.Instance.GetService<IMotoDelivery>();
            Assert.IsNotNull(serviceTest);
            Assert.IsTrue(serviceTest is IMotoDelivery);
        }

        [Test]
        public void ShouldReturnWalkDelivery()
        {
            var serviceTest = ServiceLocator.Instance.GetService<IWalkDelivery>();
            Assert.IsNotNull(serviceTest);
            Assert.IsTrue(serviceTest is IWalkDelivery);
        }

        [Test, Order(3)]
        public void ShouldReturnStringCarDelivery()
        {
            ICarDelivery service = ServiceLocator.Instance.GetService<ICarDelivery>();
            var message = service.DeliveryPackage();
            Assert.IsNotNull(service);
            Assert.IsNotNull(message);
            Assert.AreEqual(typeof(string), message.GetType());
        }

        [Test, Order(3)]
        public void ShouldReturnStringMotoDelivery()
        {
            IMotoDelivery service = ServiceLocator.Instance.GetService<IMotoDelivery>();
            var message = service.DeliveryPackage();
            Assert.IsNotNull(service);
            Assert.IsNotNull(message);
            Assert.AreEqual(typeof(string), message.GetType());
        }

        [Test, Order(3)]
        public void ShouldReturnStringWalkDelivery()
        {
            IWalkDelivery service = ServiceLocator.Instance.GetService<IWalkDelivery>();
            var message = service.DeliveryPackage();
            Assert.IsNotNull(service);
            Assert.IsNotNull(message);
            Assert.AreEqual(typeof(string), message.GetType());
        }
    }
}
