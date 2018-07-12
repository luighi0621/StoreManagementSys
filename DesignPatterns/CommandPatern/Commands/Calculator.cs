using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatern.Commands
{
    public class Calculator
    {
        private int _current = 0;

        public int Operation(char @operation, int operand)
        {
            switch (@operation) {
                case '+': _current += operand; break;
                case '-': _current -= operand; break;
                case '*': _current *= operand; break;
                case '/': _current /= operand; break;
            }
            Console.WriteLine("Current value = {0,3} (following {1} {2})", _current, @operation, operand);
            return _current;
        }
    }
}
