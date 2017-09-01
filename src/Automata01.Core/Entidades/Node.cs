using System.Collections.Generic;
using Automata01.Core.Enums;

namespace Automata01.Core.Entidades
{
    public sealed class Node
    {
        public Node(int state, IDictionary<char, Direction> possibities, bool isFinalState = false)
        {
            State = state;
            Possibities = possibities;
            IsFinalState = isFinalState;
        }

        public IDictionary<char, Direction> Possibities { get; }
        public int State { get; }
        public bool IsFinalState { get; }
    }
}
