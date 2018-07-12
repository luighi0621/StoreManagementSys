using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool.WorkSpace
{
    public class Desk
    {
        public bool Available { get; set; }
        public Desk()
        {
            Available = true;
        }
    }
}
