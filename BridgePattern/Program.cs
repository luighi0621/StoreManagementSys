using BridgePattern.Abstraction;
using BridgePattern.Implementor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            UserMessage userMsg = new UserMessage();
            userMsg.Subject = "Test Message";
            userMsg.Subject = "Hi, this is a test message.";
            userMsg.UserComments = "Replying message from another user.";

            userMsg.MessageSender = new EmailSender();
            userMsg.Send();

            userMsg.MessageSender = new SmsSender();
            userMsg.Send();

            userMsg.MessageSender = new WebServiceSender();
            userMsg.Send();

            Console.ReadKey();
        }
    }
}
