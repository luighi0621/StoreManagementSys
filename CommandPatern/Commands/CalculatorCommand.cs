using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatern.Commands
{
    public class CalculatorCommand : Command
    {
        private char _operator;
        private int _operand;
        private Calculator _calculator;

        public CalculatorCommand(Calculator calc, char @operator, int operand)
        {
            _calculator = calc;
            _operator = @operator;
            _operand = operand;
        }

        public char Operator { set { _operator = value; } }
        public int Operand { set { _operand = value; } }
        public override int Execute()
        {
            return _calculator.Operation(_operator, _operand);
        }

        public override int UnExecute()
        {
            return _calculator.Operation(Undo(_operator), _operand);
        }

        private char Undo(char @operator) {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new ArgumentException("@operator");
            }
        }
    }
}
