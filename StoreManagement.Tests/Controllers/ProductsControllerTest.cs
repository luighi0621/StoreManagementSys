using Moq;
using NUnit.Framework;
using StoreManagement.Controllers;
using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StoreManagement.Tests.Controllers
{
    [TestFixture, Category("ProductsController")]
    class ProductsControllerTest
    {
        private Mock<IProductRepository> _mockProdRepository;
        private Mock<ISupplierRepository> _mockSupRepository;
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
        }

        [Test]
        public void Index()
        {
            // Arrange
            ProductsController controller = new ProductsController(_mockSupRepository.Object, _mockProdRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<Product>), result.Model.GetType());
        }

        [Test]
        [TestCase(1)]
        [TestCase(null)]
        [TestCase(200)]
        public void Details(int? id)
        {
            // Arrange
            ProductsController controller = new ProductsController(_mockSupRepository.Object, _mockProdRepository.Object);
            if (id == null)
            {
                // Act
                ActionResult result = controller.Details(id) as ActionResult;
                int statusCode = ((HttpStatusCodeResult)result).StatusCode;
                Assert.AreEqual((int)HttpStatusCode.BadRequest, statusCode);
                Assert.AreEqual(typeof(HttpStatusCodeResult), result.GetType());
            }
            else
            {
                // Act
                ActionResult result = controller.Details(id) as ActionResult;

                if (id > _mockProdRepository.Object.Count())
                {
                    Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
                }
                else{
                    // Assert
                    Assert.IsNotNull(result);
                    Assert.AreEqual(typeof(Product), ((ViewResult)result).Model.GetType());
                }
            }
        }

        [Test]
        public void Create()
        {
            // Arrange
            ProductsController controller = new ProductsController(_mockSupRepository.Object, _mockProdRepository.Object);

            // Act
            ViewResult result = controller.Create() as ViewResult;
            SelectList sList = result.ViewBag.Suppliers;
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(SelectList), result.ViewBag.Suppliers.GetType());
        }

        [Test]
        [TestCase(1)]
        [TestCase(null)]
        [TestCase(200)]
        public void Edit(int? id)
        {
            ProductsController controller = new ProductsController(_mockSupRepository.Object, _mockProdRepository.Object);
            ActionResult result = controller.Edit(id) as ActionResult;

            if (id == null)
            {
                int statusCode = ((HttpStatusCodeResult)result).StatusCode;
                Assert.AreEqual((int)HttpStatusCode.BadRequest, statusCode);
                Assert.AreEqual(typeof(HttpStatusCodeResult), result.GetType());
            }
            else
            {
                if (id > _mockProdRepository.Object.Count())
                {
                    Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
                }
                else
                {
                    Assert.IsNotNull(result);
                    Assert.AreEqual(typeof(Product), ((ViewResult)result).Model.GetType());
                }
            }
        }

        [Test]
        public void DeleteConfirmed()
        {
            ProductsController controller = new ProductsController(_mockSupRepository.Object, _mockProdRepository.Object);
            RedirectToRouteResult redirect = controller.DeleteConfirmed(1) as RedirectToRouteResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }
    }
}
