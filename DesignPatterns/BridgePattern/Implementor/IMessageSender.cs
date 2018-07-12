﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Implementor
{
    public interface IMessageSender
    {
        bool SendMessage(string subject, string body);
    }
}