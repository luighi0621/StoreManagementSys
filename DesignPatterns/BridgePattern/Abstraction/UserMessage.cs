using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Abstraction
{
    public class UserMessage : Message
    {
        public string UserComments { get; set; }

        public override bool Send()
        {
            if (MessageSender == null) return false;
            string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
            return MessageSender.SendMessage(Subject, fullBody);
        }
    }
}
