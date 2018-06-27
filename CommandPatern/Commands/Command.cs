using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatern.Commands
{
    public abstract class Command
    {
        public abstract int Execute();
        public abstract int UnExecute();
    }
}
