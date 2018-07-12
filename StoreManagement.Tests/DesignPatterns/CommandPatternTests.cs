using CommandPatern.Commands;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class CommandPatternTests
    {
        private CommandPatern.User User;
        //private Mock<CommandPatern.User> _MockUser;
        //private Mock<CalculatorCommand> _calcCommand;

        //[SetUp]
        //public void SetuUp()
        //{
        //    _MockUser = new Mock<CommandPatern.User>();
        //    User = (CommandPatern.User)_MockUser.Object;
        //}

        [Test, Category("Command")]
        public void ExecuteCalculator()
        {
            User = new CommandPatern.User();
            var result = User.Compute('+', 10);
            Assert.AreEqual(10, result);
        }

        [Test, Category("Command")]
        public void ExecuteCalculatorSeveralTimes()
        {
            User = new CommandPatern.User();
            var result = User.Compute('+', 10);
            result = User.Compute('-', 5);
            result = User.Compute('*', 1);
            result = User.Compute('/', 5);
            Assert.AreEqual(1, result);
        }

        [Test, Category("Command")]
        public void ExecuteCalculatorUndo2levels()
        {
            User = new CommandPatern.User();
            var result = User.Compute('+', 10);
            result = User.Compute('-', 5);
            result = User.Compute('*', 1);
            result = User.Compute('/', 5);

            var undo2 = User.Undo(2);
            Assert.AreEqual(1, result);
            Assert.AreEqual(5, undo2);
        }
        [Test, Category("Command")]
        public void ExecuteCalculatorRedo3levels()
        {
            User = new CommandPatern.User();
            var result = User.Compute('+', 10);
            result = User.Compute('-', 5);
            result = User.Compute('*', 1);
            result = User.Compute('/', 5);

            var redo3 = User.Undo(2);
            Assert.AreEqual(1, result);
            Assert.AreEqual(5, redo3);
        }

        [Test, Category("Command")]
        public void ExecuteCalculatorWithUndo()
        {
            User = new CommandPatern.User();
            var result = User.Compute('+', 10);
            Assert.AreEqual(10, result);
            result = User.Undo(1);
            Assert.AreEqual(0, result);
        }

        [Test, Category("Command")]
        public void ShouldThrowExceptionWithUndoManyLevels()
        {
            User = new CommandPatern.User();
            var ex = Assert.Throws<IndexOutOfRangeException>(()=> User.Undo(4));
            Assert.That(ex.Message, Is.EqualTo("Too much levels."));
        }

        [Test, Category("Command")]
        public void ShouldThrowExceptionWithRedoManyLevels()
        {
            User = new CommandPatern.User();
            var ex = Assert.Throws<IndexOutOfRangeException>(() => User.Redo(4));
            Assert.That(ex.Message, Is.EqualTo("Too much levels."));
        }
    }
}
