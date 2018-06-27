using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Subjects
{
    public class MathProxy : IMath
    {
        public MathProxy(IMath ma)
        {
            _math = ma;
        }
        public MathProxy()
        {
            _math = new Math();
        }
        private IMath _math;
        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }

        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }
    }
}
