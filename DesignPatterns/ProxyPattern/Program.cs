using ProxyPattern.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MathProxy proxy = new MathProxy();

            Console.WriteLine("4 + 2 = {0}", proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = {0}", proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = {0}", proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = {0}", proxy.Div(4, 2));
            Console.ReadKey();
        }
    }
}
