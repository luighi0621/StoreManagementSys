using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Abstraction
{
    public class SystemMessage : Message
    {
        public override bool Send()
        {
            if (MessageSender == null) return false;
            return MessageSender.SendMessage(Subject, Body);
        }
    }
}
