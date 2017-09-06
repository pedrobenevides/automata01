using System;
using System.Collections.Generic;
using System.Linq;

namespace Automata01.Core.Entidades
{
    public abstract class Automata
    {
        protected Automata(IReadOnlyCollection<char> alphabet, IReadOnlyCollection<char> grammar, IReadOnlyCollection<Node> universe)
        {
            Alphabet = alphabet;
            Grammar = grammar;

            if (!IsValidUniverse(universe.ToList()))
                throw new Exception("This is not a valid universe");

            Universe = universe;
        }

        public IReadOnlyCollection<char> Alphabet { get; }
        public IReadOnlyCollection<char> Grammar { get; }
        public IReadOnlyCollection<Node> Universe { get; }

        public abstract bool IsValidSequence(Action<string> printValue);

        protected static bool IsValidUniverse(ICollection<Node> universe)
        {
            var finalStatesCount = universe.Count(u => u.IsFinalState);

            return finalStatesCount > 0;
        }

        protected static string LogNext(int nextNode, int currentNode) => nextNode > currentNode
            ? $"vai para Q{nextNode}"
            : nextNode < currentNode
                ? $"volta para Q{nextNode}"
                : $"permanece em Q{currentNode}";

        protected bool BelongsToAlphabet(char value)
            => Alphabet.Contains(value);
    }
}