using NUnit.Framework;
using ObjectPool;
using ObjectPool.WorkSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class ObjectPoolTests
    {
        CustomPool<Desk, Employee> pool;

        [SetUp]
        public void SetUp()
        {
            pool = DeskPool.Instance;
        }

        [Test, Category("ObjectPool"), Order(1)]
        public void ObjectPoolEmpty()
        {
            Assert.AreEqual(0, pool.Count());
        }

        [Test, Category("ObjectPool")]
        public void CreatesNewOneForNewEmployee()
        {
            Employee e = new Employee("testA");
            pool.Acquire(e);
            bool desksAvailable = pool.GetList().Keys.All(d => d.Available);
            Assert.AreEqual(1, pool.Count());
            Assert.IsFalse(e.Desk.Available);
            Assert.IsFalse(desksAvailable);
            pool.Release(e.Desk);
        }

        [Test, Category("ObjectPool")]
        public void ReleaseDesk()
        {
            Employee e = new Employee("testA");
            pool.Acquire(e);
            pool.Release(e.Desk);
            bool desksAvailable = pool.GetList().Keys.All(d => d.Available);
            Assert.AreEqual(1, pool.Count());
            Assert.IsNull(e.Desk);
            Assert.IsTrue(desksAvailable);
        }

        [Test, Category("ObjectPool")]
        public void NoCreatesNewOneForNewEmployee()
        {
            Employee e = new Employee("testA");
            pool.Acquire(e);
            pool.Release(e.Desk);
            Employee e1 = new Employee("testB");
            pool.Acquire(e1);
            Assert.AreEqual(1, pool.Count());
            Assert.IsNull(e.Desk);
            Assert.IsNotNull(e1.Desk);
            pool.Release(e1.Desk);
        }
    }
}
