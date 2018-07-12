using BuilderPattern;
using BuilderPattern.Builders;
using NUnit.Framework;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class BuilderPatternTests
    {
        private VehicleBuilder _builder;
        private readonly Shop _shop;
        public BuilderPatternTests()
        {
            _shop = new Shop();
        }

        [Test, Category("Builder")]
        public void ReturnsACar()
        {
            _builder = new CarBuilder();
            Vehicle car = _shop.Build(_builder);
            Assert.IsTrue(car["doors"] == "4");
            Assert.IsTrue(car["wheels"] == "4");
            Assert.IsTrue(car["engine"] == "2500 cc");
            Assert.IsTrue(car["frame"] == "Car frame");
            Assert.IsTrue(car.Type == "Car");
        }

        [Test, Category("Builder")]
        public void ReturnsAMotorcycle()
        {
            _builder = new MotorCycleBuilder();
            Vehicle car = _shop.Build(_builder);
            Assert.IsTrue(car["doors"] == "0");
            Assert.IsTrue(car["wheels"] == "2");
            Assert.IsTrue(car["engine"] == "500 cc");
            Assert.IsTrue(car["frame"] == "Motorcycle frame");
            Assert.IsTrue(car.Type == "MotorCycle");
        }

        [Test, Category("Builder")]
        public void ReturnsAnScooter()
        {
            _builder = new ScooterBuilder();
            Vehicle car = _shop.Build(_builder);
            Assert.IsTrue(car["doors"] == "0");
            Assert.IsTrue(car["wheels"] == "3");
            Assert.IsTrue(car["engine"] == "50 cc");
            Assert.IsTrue(car["frame"] == "Scooter frame");
            Assert.IsTrue(car.Type == "Scooter");
        }
    }
}
