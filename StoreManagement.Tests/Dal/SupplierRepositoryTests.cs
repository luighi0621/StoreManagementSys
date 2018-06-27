using Moq;
using NUnit.Framework;
using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.Dal
{
    [TestFixture, Category("SupplierRepository")]
    class SupplierRepositoryTests
    {
        private Mock<ISupplierRepository> _mockSupRepository;
        public ISupplierRepository MockSupRepository;
        public TestContext TextContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            IList<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    Name = "Producto1",
                    SupplierCode = "Prod1",
                    ID = 1
                },
                new Supplier()
                {
                    Name = "Producto2",
                    SupplierCode = "Prod2",
                    ID = 2
                },
                new Supplier()
                {
                    Name = "Producto3",
                    SupplierCode = "Prod3",
                    ID = 3
                }
            };
            _mockSupRepository = new Mock<ISupplierRepository>();
            _mockSupRepository.Setup(mr => mr.GetAll()).Returns(suppliers);

            _mockSupRepository.Setup(mr => mr.Count()).Returns(suppliers.Count);

            _mockSupRepository.Setup(mr => mr.Get(It.IsAny<Expression<Func<Supplier, bool>>>())).Returns(
                (Expression<Func<Supplier, bool>> expression) =>
                {
                    var userQuery = suppliers.Where(expression.Compile()).FirstOrDefault();
                    return userQuery;
                }
                );
            _mockSupRepository.Setup(mr => mr.Delete(It.IsAny<Supplier>()))
                .Callback(
                (Supplier us) =>
                {
                    suppliers.Remove(us);
                }
                ).Verifiable();
            _mockSupRepository.Setup(mr => mr.Create(It.IsAny<Supplier>()))
                .Callback(
                (Supplier us) => {
                    us.ID = suppliers.Count + 1;
                    suppliers.Add(us);
                }
                );
            _mockSupRepository.Setup(mr => mr.Update(It.IsAny<Supplier>()))
                .Callback(
                (Supplier us) => {
                    int index = suppliers.IndexOf(us);
                    if (index != -1)
                    {
                        suppliers[index] = us;
                    }
                }
                )
                .Verifiable();
            _mockSupRepository.Setup(mr => mr.ExecuteQuery(It.IsAny<string>())).Throws(new NotSupportedException("Query executions not supported."));

            this.MockSupRepository = _mockSupRepository.Object;
        }

        [Test]
        public void ReturnCountOfRepository()
        {
            Assert.AreEqual(3, MockSupRepository.Count());
        }

        [Test]
        public void ReturnAllSupliers()
        {
            IList<Supplier> usersTest = this.MockSupRepository.GetAll();

            Assert.IsNotNull(usersTest);
            Assert.AreEqual(3, usersTest.Count);
        }

        [Test]
        public void QueryExecutionThrowsException()
        {
            string messageExc = "Query executions not supported.";
            var ex = Assert.Throws<NotSupportedException>(() => MockSupRepository.ExecuteQuery(""));
            Assert.That(ex.Message, Is.EqualTo(messageExc));
        }

        [Test]
        public void ReturnASupplierDependingQuery()
        {
            Supplier supTest = this.MockSupRepository.Get(u => u.ID == 3);
            Assert.IsNotNull(supTest);
            Assert.AreEqual("Producto3", supTest.Name);
            Assert.AreEqual("Prod3", supTest.SupplierCode);
        }

        [Test]
        public void DeleteSupplierFromRepository()
        {
            Supplier toDelete = MockSupRepository.Get(u => u.ID == 3);
            MockSupRepository.Delete(toDelete);
            IList<Supplier> list = MockSupRepository.GetAll();
            Supplier deleted = MockSupRepository.Get(u => u.ID == 3);
            Assert.IsNull(deleted);
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void CreateSupplierRepository()
        {
            Supplier newSupp = new Supplier()
            {
                Name = "Producto4",
                SupplierCode = "Prod4"
            };
            MockSupRepository.Create(newSupp);
            IList<Supplier> list = MockSupRepository.GetAll();
            Supplier Created = MockSupRepository.Get(u => u.SupplierCode == "Prod4");
            Assert.IsNotNull(Created);
            Assert.AreNotEqual(default(int), Created.ID);
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void UpdateSupplierRepository()
        {
            Supplier suppTest = this.MockSupRepository.Get(u => u.ID == 3);
            suppTest.Name = "Modified3";
            suppTest.SupplierCode = "Mod3";
            MockSupRepository.Update(suppTest);
            _mockSupRepository.Verify(x => x.Update(It.IsAny<Supplier>()));
            Supplier modified = this.MockSupRepository.Get(u => u.ID == 3);
            IList<Supplier> list = MockSupRepository.GetAll();
            Assert.IsNotNull(modified);
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(suppTest.Name, modified.Name);
            Assert.AreEqual(suppTest.SupplierCode, modified.SupplierCode);
        }
    }
}
