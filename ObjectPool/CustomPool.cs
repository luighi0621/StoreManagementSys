using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ObjectPool
{
    public abstract class CustomPool<T, O>
    {
        protected Dictionary<T, O> objects;

        public abstract void Acquire(O o);
        public abstract void Release(T t);

        public int Count()
        {
            return objects.Count;
        }

        public Dictionary<T,O> GetList()
        {
            return objects;
        }
    }
}
