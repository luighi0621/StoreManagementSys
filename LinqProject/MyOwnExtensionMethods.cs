using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public static class MyOwnExtensionMethods
    {
        public static IEnumerable<T> OfType<T>(this IEnumerable source)
        {
            foreach (object item in source)
            {
                if (item is T)
                    yield return (T)item;
            }
        }
        
    }
}
