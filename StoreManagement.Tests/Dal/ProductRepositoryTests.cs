using Moq;
using NUnit.Framework;
using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreManagement.Tests.Dal
{
    [TestFixture, Category("ProductRepository")]
    public class ProductRepositoryTests
    {
        private Mock<IProductRepository> _mockProdRepository;
        public IProductRepository MockProdRepository;
        public TestContext TextContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            IList<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Producto1",
                    ProductCode = "Prod1",
                    Id = 1
                },
                new Product()
                {
                    Name = "Producto2",
                    ProductCode = "Prod2",
                    Id = 2
                },
                new Product()
                {
                    Name = "Producto3",
                    ProductCode = "Prod3",
                    Id = 3
                }
            };
            _mockProdRepository = new Mock<IProductRepository>();
            _mockProdRepository.Setup(mr => mr.GetAll()).Returns(products);

            _mockProdRepository.Setup(mr => mr.Count()).Returns(products.Count);

            _mockProdRepository.Setup(mr => mr.Get(It.IsAny<Expression<Func<Product, bool>>>())).Returns(
                (Expression<Func<Product, bool>> expression) =>
                {
                    var userQuery = products.Where(expression.Compile()).FirstOrDefault();
                    return userQuery;
                }
                );
            _mockProdRepository.Setup(mr => mr.Delete(It.IsAny<Product>()))
                .Callback(
                (Product us) =>
                {
                    products.Remove(us);
                }
                ).Verifiable();
            _mockProdRepository.Setup(mr => mr.Create(It.IsAny<Product>()))
                .Callback(
                (Product us) => {
                    us.Id = products.Count + 1;
                    products.Add(us);
                }
                );
            _mockProdRepository.Setup(mr => mr.Update(It.IsAny<Product>()))
                .Callback(
                (Product us) => {
                    int index = products.IndexOf(us);
                    if (index != -1)
                    {
                        products[index] = us;
                    }
                }
                )
                .Verifiable();
            _mockProdRepository.Setup(mr => mr.ExecuteQuery(It.IsAny<string>())).Throws(new NotSupportedException("Query executions not supported."));
            this.MockProdRepository = _mockProdRepository.Object;
        }

        [Test]
        public void ReturnCountOfRepository()
        {
            Assert.AreEqual(3, MockProdRepository.Count());
        }

        [Test]
        public void ReturnAllProducts()
        {
            IList<Product> usersTest = this.MockProdRepository.GetAll();

            Assert.IsNotNull(usersTest);
            Assert.AreEqual(3, usersTest.Count);
        }

        [Test]
        public void QueryExecutionThrowsException()
        {
            string messageExc = "Query executions not supported.";
            var ex = Assert.Throws<NotSupportedException>(() => MockProdRepository.ExecuteQuery(""));
            Assert.That(ex.Message, Is.EqualTo(messageExc));
        }

        [Test]
        public void ReturnAProdDependingQuery()
        {
            Product prodTest = this.MockProdRepository.Get(u => u.Id == 3);
            Assert.IsNotNull(prodTest);
            Assert.AreEqual("Producto3", prodTest.Name);
            Assert.AreEqual("Prod3", prodTest.ProductCode);
        }

        [Test]
        public void DeleteProdFromRepository()
        {
            Product toDelete = MockProdRepository.Get(u => u.Id == 3);
            MockProdRepository.Delete(toDelete);
            IList<Product> list = MockProdRepository.GetAll();
            Product deleted = MockProdRepository.Get(u => u.Id == 3);
            Assert.IsNull(deleted);
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void CreateProdRepository()
        {
            Product newProd = new Product()
            {
                Name = "Producto4",
                ProductCode = "Prod4"
            };
            MockProdRepository.Create(newProd);
            IList<Product> list = MockProdRepository.GetAll();
            Product Created = MockProdRepository.Get(u => u.ProductCode == "Prod4");
            Assert.IsNotNull(Created);
            Assert.AreNotEqual(default(int), Created.Id);
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void UpdateProdRepository()
        {
            Product prodTest = this.MockProdRepository.Get(u => u.Id == 3);
            prodTest.Name = "Modified3";
            prodTest.ProductCode= "Mod3";
            MockProdRepository.Update(prodTest);
            _mockProdRepository.Verify(x => x.Update(It.IsAny<Product>()));
            Product modified = this.MockProdRepository.Get(u => u.Id == 3);
            IList<Product> list = MockProdRepository.GetAll();
            Assert.IsNotNull(modified);
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(prodTest.Name, modified.Name);
            Assert.AreEqual(prodTest.ProductCode, modified.ProductCode);
        }
    }
}
