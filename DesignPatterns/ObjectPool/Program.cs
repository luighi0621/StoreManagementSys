using ObjectPool.WorkSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomPool<Desk, Employee> pool = DeskPool.Instance;

            Employee emp1 = new Employee("Luis");
            pool.Acquire(emp1);
            pool.Release(emp1.Desk);

            Employee emp2 = new Employee("Pedro");
            pool.Acquire(emp2);

            Console.ReadKey();
        }
    }
}
