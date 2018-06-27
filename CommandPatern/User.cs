using CommandPatern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatern
{
    public class User
    {
        private Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;



        public int Redo(int levels)
        {
            if(levels > _commands.Count)
            {
                throw new IndexOutOfRangeException("Too much levels.");
            }
            int res = 0;
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if(_current < _commands.Count - 1)
                {
                    Command command = _commands[_current++];
                    res = command.Execute();
                }
            }
            return res;
        }

        public int Undo(int levels)
        {
            if (levels > _commands.Count)
            {
                throw new IndexOutOfRangeException("Too much levels.");
            }
            int res = 0;
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    Command command = _commands[-- _current] as Command;
                    res = command.UnExecute();
                }
            }
            return res;
        }

        public int Compute(char @operator, int operand)
        {
            Command command = new CalculatorCommand(_calculator, @operator, operand);
            int res = command.Execute();

            _commands.Add(command);
            _current++;
            return res;
        }
    }
}
