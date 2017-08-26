using System;
using Automata01.Core.Enums;

namespace Automata01.Core.Entidades
{
    public class Node
    {
        private readonly Func<char, Direction> _func;

        public Node(string stateValue, Func<char, Direction> func)
        {
            _func = func;
            StateValue = stateValue;
        }

        public Direction Direction { get; set; }
        public string StateValue { get; private set; }

        public Direction Transition(char value) => _func(value);
    }
}