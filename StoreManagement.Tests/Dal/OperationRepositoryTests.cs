using Moq;
using NUnit.Framework;
using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.Dal
{
    [TestFixture, Category("OperationRepository")]
    public class OperationRepositoryTests
    {
        private Mock<IOperationRepository> _mockOperationRepository;
        public IOperationRepository MockOperationRepository;
        public TestContext TextContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            IList<Operation> operations = new List<Operation>()
            {
                new Operation()
                {
                    Operation1 = "Insert",
                    Table = "Customer",
                    Id = 1,
                    Description = "Customer Pedro was added.",
                    Date = new DateTime(2018, 06, 25, 12, 35, 50)
                },
                new Operation()
                {
                    Operation1 = "Delete",
                    Table = "Product",
                    Description = "Product Pil was deleted.",
                    Date = new DateTime(2018, 06, 26, 09, 15, 10),
                    Id = 2
                }
            };
            _mockOperationRepository = new Mock<IOperationRepository>();
            _mockOperationRepository.Setup(mr => mr.GetAll()).Returns(operations);

            _mockOperationRepository.Setup(mr => mr.Count()).Returns(operations.Count);

            _mockOperationRepository.Setup(mr => mr.Get(It.IsAny<Expression<Func<Operation, bool>>>())).Throws(new NotSupportedException("Operation not supported."));
            _mockOperationRepository.Setup(mr => mr.Delete(It.IsAny<Operation>())).Throws(new NotSupportedException("Operation not supported."));
            _mockOperationRepository.Setup(mr => mr.Create(It.IsAny<Operation>())).Throws(new NotSupportedException("Operation not supported."));
            _mockOperationRepository.Setup(mr => mr.Update(It.IsAny<Operation>())).Throws(new NotSupportedException("Operation not supported."));
            _mockOperationRepository.Setup(mr => mr.ExecuteQuery(It.IsAny<string>())).Returns(new DataTable());
            this.MockOperationRepository = _mockOperationRepository.Object;
        }

        [Test]
        public void CreateOperationThrowsException()
        {
            string messageExc = "Operation not supported.";
            var ex = Assert.Throws<NotSupportedException>(() => MockOperationRepository.Create(It.IsAny<Operation>()));
            Assert.That(ex.Message, Is.EqualTo(messageExc));
        }

        [Test]
        public void DeleteOperationThrowsException()
        {
            string messageExc = "Operation not supported.";
            var ex = Assert.Throws<NotSupportedException>(() => MockOperationRepository.Delete(It.IsAny<Operation>()));
            Assert.That(ex.Message, Is.EqualTo(messageExc));
        }

        [Test]
        public void UpdateOperationThrowsException()
        {
            string messageExc = "Operation not supported.";
            var ex = Assert.Throws<NotSupportedException>(() => MockOperationRepository.Update(It.IsAny<Operation>()));
            Assert.That(ex.Message, Is.EqualTo(messageExc));
        }

        [Test]
        public void GetOperationThrowsException()
        {
            string messageExc = "Operation not supported.";
            var ex = Assert.Throws<NotSupportedException>(() => MockOperationRepository.Get(It.IsAny<Expression<Func<Operation, bool>>>()));
            Assert.That(ex.Message, Is.EqualTo(messageExc));
        }

        [Test]
        public void GetAllOperations()
        {
            var list = MockOperationRepository.GetAll();
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void GetCunt()
        {
            var count = MockOperationRepository.Count();
            Assert.AreEqual(typeof(long), count.GetType());
            Assert.AreEqual(2, count);
        }

        [Test]
        public void ExecuteQueryReturnsDataTable()
        {
            string query = string.Empty;
            var dt = MockOperationRepository.ExecuteQuery(query);
            Assert.IsNotNull(dt);
            Assert.AreEqual(typeof(DataTable), dt.GetType());
        }
    }
}
