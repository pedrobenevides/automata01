using System.Collections.Generic;
using Automata01.Core.Enums;

namespace Automata01.Core.Entidades
{
    public sealed class Node
    {
        public Node(int state, IDictionary<char, int> possibities, bool isFinalState = false)
        {
            State = state;
            Possibities = possibities;
            IsFinalState = isFinalState;
        }

        public IDictionary<char, int> Possibities { get; }
        public int State { get; }
        public bool IsFinalState { get; }
    }
}
