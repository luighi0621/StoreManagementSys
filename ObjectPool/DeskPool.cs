using ObjectPool.WorkSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class DeskPool : CustomPool<Desk, Employee>
    {
        private static DeskPool _instance;
        public DeskPool()
        {
            objects = new Dictionary<Desk, Employee>();
        }
        public static DeskPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeskPool();
                }
                return _instance;
            }
        }

        public override void Acquire(Employee e)
        {
            if(e != null && e.Desk == null)
            {
                Employee eeeee;
                eeeee = objects.Values.Where(emp => emp != null && emp == e).FirstOrDefault();
                Desk des;
                if(eeeee == null)
                {
                    des = objects.Keys.Where(d => d.Available).FirstOrDefault();
                    if(des == null)
                    {
                        Console.WriteLine("not available creating new one");
                        des = new Desk();
                    }
                    objects[des] = e;
                    e.Desk = des;
                    e.Desk.Available = false;
                }
                Console.WriteLine("giving desk to {0}", e.Name);
            }
        }

        public override void Release(Desk e)
        {
            if(e != null)
            {
                var eeeee = objects.Keys.Where(emp => emp== e).FirstOrDefault();
                eeeee.Available = true;
                var employee = objects[eeeee];
                employee.Desk = null;
                objects[eeeee] = null;
                Console.WriteLine("returnig desk");
            }
        }
        
    }
}
