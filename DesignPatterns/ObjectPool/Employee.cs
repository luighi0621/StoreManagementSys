using ObjectPool.WorkSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class Employee
    {
        public string Name { get; private set; }
        public Desk Desk { get; set; }

        public Employee(string name)
        {
            Name = name;
        }
    }
}
