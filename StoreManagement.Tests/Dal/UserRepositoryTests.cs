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
    [TestFixture, Category("UserRepository")]
    public class UserRepositoryTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        public IUserRepository MockUserRepository;
        public TestContext TextContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            IList<User> users = new List<User>()
            {
                new User()
                {
                    Firstname = "Jose",
                    Lastname = "Perez",
                    ID = 1
                },
                new User()
                {
                    Firstname = "Maria",
                    Lastname = "lopez",
                    ID = 2
                },
                new User()
                {
                    Firstname = "Clelia",
                    Lastname = "Aguilar",
                    ID = 3
                }
            };
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserRepository.Setup(mr => mr.GetAll()).Returns(users);

            _mockUserRepository.Setup(mr => mr.Count()).Returns(users.Count);

            _mockUserRepository.Setup(mr => mr.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(
                (Expression<Func<User, bool>> expression) =>
                {
                    var userQuery = users.Where(expression.Compile()).FirstOrDefault();
                    return userQuery;
                }
                );
            _mockUserRepository.Setup(mr => mr.Delete(It.IsAny<User>()))
                .Callback(
                (User us) =>
                {
                    users.Remove(us);
                }
                ).Verifiable();
            _mockUserRepository.Setup(mr => mr.Create(It.IsAny<User>()))
                .Callback(
                (User us) => {
                    us.ID = users.Count + 1;
                    users.Add(us);
                }
                );
            _mockUserRepository.Setup(mr => mr.Update(It.IsAny<User>()))
                .Callback(
                (User us) => {
                    int index = users.IndexOf(us);
                    if (index != -1)
                    {
                        users[index] = us;
                    }
                }
                )
                .Verifiable();

            this.MockUserRepository = _mockUserRepository.Object;
        }

        [Test]
        public void ReturnCountOfRepository()
        {
            Assert.AreEqual(3, MockUserRepository.Count());
        }

        [Test]
        public void ReturnAllUsers()
        {
            IList<User> usersTest = this.MockUserRepository.GetAll();

            Assert.IsNotNull(usersTest);
            Assert.AreEqual(3, usersTest.Count);
        }

        [Test]
        public void ReturnAUserDependingQuery()
        {
            User usersTest = this.MockUserRepository.Get(u => u.ID == 3);
            Assert.IsNotNull(usersTest);
            Assert.AreEqual("Clelia", usersTest.Firstname);
            Assert.AreEqual("Aguilar", usersTest.Lastname);
        }

        [Test]
        public void DeleteUserFromRepository()
        {
            User toDelete = MockUserRepository.Get(u => u.ID == 3);
            MockUserRepository.Delete(toDelete);
            IList<User> list = MockUserRepository.GetAll();
            User deleted = MockUserRepository.Get(u => u.ID == 3);
            Assert.IsNull(deleted);
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void CreateUserRepository()
        {
            User newUser = new User()
            {
                Firstname = "Karen",
                Lastname = "Valenzuela"
            };
            MockUserRepository.Create(newUser);
            IList<User> list = MockUserRepository.GetAll();
            User Created = MockUserRepository.Get(u => u.Lastname == "Valenzuela");
            Assert.IsNotNull(Created);
            Assert.AreNotEqual(default(int), Created.ID);
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void UpdateUserRepository()
        {
            User usersTest = this.MockUserRepository.Get(u => u.ID == 3);
            usersTest.Firstname = "Modified";
            usersTest.Lastname = "Modified";
            MockUserRepository.Update(usersTest);
            _mockUserRepository.Verify(x => x.Update(It.IsAny<User>()));
            User modified = this.MockUserRepository.Get(u => u.ID == 3);
            IList<User> list = MockUserRepository.GetAll();
            Assert.IsNotNull(modified);
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(usersTest.Firstname, modified.Firstname);
            Assert.AreEqual(usersTest.Lastname, modified.Lastname);
        }
    }
}
