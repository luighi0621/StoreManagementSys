using BridgePattern.Abstraction;
using BridgePattern.Implementor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Tests.DesignPatterns
{
    [TestFixture]
    public class BridgePatternTest
    {
        private UserMessage userMessage;
        private SystemMessage SystemMessage;

        private Mock<IMessageSender> _emailMock;
        private Mock<IMessageSender> _smsMock;
        private Mock<IMessageSender> _webMock;

        private const string title = "Title Test";
        private const string body = "Body Test";
        private const string userComment = "Comment Test";

        [SetUp]
        public void SetUp()
        {
            _emailMock = new Mock<IMessageSender>();
            _emailMock.Setup(e => e.SendMessage(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            _smsMock = new Mock<IMessageSender>();
            _smsMock.Setup(e => e.SendMessage(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            _webMock = new Mock<IMessageSender>();
            _webMock.Setup(e => e.SendMessage(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            userMessage = new UserMessage();
            userMessage.Subject = title;
            userMessage.Body = body;
            userMessage.UserComments = userComment;

            SystemMessage = new SystemMessage();
            SystemMessage.Subject = title;
            SystemMessage.Body = body;
        }

        [Test, Category("Bridge")]
        public void MessageNotSendBecauseSenderIsNull()
        {
            bool sent = userMessage.Send();
            Assert.IsFalse(sent);
        }

        [Test, Category("Bridge")]
        public void UMSendSMS()
        {
            userMessage.MessageSender = _smsMock.Object;
            bool sent = userMessage.Send();
            _smsMock.Verify(s=>s.SendMessage(It.IsAny<string>(), It.IsAny<string>()));
            _emailMock.VerifyNoOtherCalls();
            _webMock.VerifyNoOtherCalls();
            Assert.IsTrue(sent);
        }

        [Test, Category("Bridge")]
        public void UMSendWeb()
        {
            userMessage.MessageSender = _webMock.Object;
            bool sent = userMessage.Send();
            _webMock.Verify(s => s.SendMessage(It.IsAny<string>(), It.IsAny<string>()));
            _smsMock.VerifyNoOtherCalls();
            _emailMock.VerifyNoOtherCalls();
            Assert.IsTrue(sent);
        }

        [Test, Category("Bridge")]
        public void SMSendeMail()
        {
            SystemMessage.MessageSender = _emailMock.Object;
            bool sent = SystemMessage.Send();
            _emailMock.Verify(s => s.SendMessage(It.IsAny<string>(), It.IsAny<string>()));
            _smsMock.VerifyNoOtherCalls();
            _webMock.VerifyNoOtherCalls();
            Assert.IsTrue(sent);
        }
    }
}
