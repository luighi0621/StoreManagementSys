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
    [TestFixture, Category("CustomerRepository")]
    class CustomerRepositoryTests
    {
        private Mock<ICustomerRepository> _mockCustomerRepository;
        public ICustomerRepository MockCustomerRepository;
        public TestContext TextContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            IList<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Firstname = "Jose",
                    Lastname = "Perez",
                    ID = 1
                },
                new Customer()
                {
                    Firstname = "Maria",
                    Lastname = "lopez",
                    ID = 2
                },
                new Customer()
                {
                    Firstname = "Clelia",
                    Lastname = "Aguilar",
                    ID = 3
                }
            };
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockCustomerRepository.Setup(mr => mr.GetAll()).Returns(customers);

            _mockCustomerRepository.Setup(mr => mr.Count()).Returns(customers.Count);

            _mockCustomerRepository.Setup(mr => mr.Get(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(
                (Expression<Func<Customer, bool>> expression) =>
                {
                    var userQuery = customers.Where(expression.Compile()).FirstOrDefault();
                    return userQuery;
                }
                );
            _mockCustomerRepository.Setup(mr => mr.Delete(It.IsAny<Customer>()))
                .Callback(
                (Customer us) =>
                {
                    customers.Remove(us);
                }
                ).Verifiable();
            _mockCustomerRepository.Setup(mr => mr.Create(It.IsAny<Customer>()))
                .Callback(
                (Customer us) => {
                    us.ID = customers.Count + 1;
                    customers.Add(us);
                }
                );
            _mockCustomerRepository.Setup(mr => mr.Update(It.IsAny<Customer>()))
                .Callback(
                (Customer us) => {
                    int index = customers.IndexOf(us);
                    if (index != -1)
                    {
                        customers[index] = us;
                    }
                }
                )
                .Verifiable();

            this.MockCustomerRepository = _mockCustomerRepository.Object;
        }

        [Test]
        public void ReturnCountOfRepository()
        {
            Assert.AreEqual(3, MockCustomerRepository.Count());
        }

        [Test]
        public void ReturnAllCustomers()
        {
            IList<Customer> customersTest = this.MockCustomerRepository.GetAll();

            Assert.IsNotNull(customersTest);
            Assert.AreEqual(3, customersTest.Count);
        }

        [Test]
        public void ReturnACustomerDependingQuery()
        {
            Customer customerTest = this.MockCustomerRepository.Get(u => u.ID == 3);
            Assert.IsNotNull(customerTest);
            Assert.AreEqual("Clelia", customerTest.Firstname);
            Assert.AreEqual("Aguilar", customerTest.Lastname);
        }

        [Test]
        public void DeleteCustomerFromRepository()
        {
            Customer toDelete = MockCustomerRepository.Get(u => u.ID == 3);
            MockCustomerRepository.Delete(toDelete);
            IList<Customer> list = MockCustomerRepository.GetAll();
            Customer deleted = MockCustomerRepository.Get(u => u.ID == 3);
            Assert.IsNull(deleted);
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void CreateCustomerRepository()
        {
            Customer newCustomer = new Customer()
            {
                Firstname = "Karen",
                Lastname = "Valenzuela"
            };
            MockCustomerRepository.Create(newCustomer);
            IList<Customer> list = MockCustomerRepository.GetAll();
            Customer Created = MockCustomerRepository.Get(u => u.Lastname == "Valenzuela");
            Assert.IsNotNull(Created);
            Assert.AreNotEqual(default(int), Created.ID);
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void UpdateCustomerRepository()
        {
            Customer CustomerTest = this.MockCustomerRepository.Get(u => u.ID == 3);
            CustomerTest.Firstname = "Modified";
            CustomerTest.Lastname = "Modified";
            MockCustomerRepository.Update(CustomerTest);
            _mockCustomerRepository.Verify(x => x.Update(It.IsAny<Customer>()));
            Customer modified = this.MockCustomerRepository.Get(u => u.ID == 3);
            IList<Customer> list = MockCustomerRepository.GetAll();
            Assert.IsNotNull(modified);
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(CustomerTest.Firstname, modified.Firstname);
            Assert.AreEqual(CustomerTest.Lastname, modified.Lastname);
        }
    }
}
