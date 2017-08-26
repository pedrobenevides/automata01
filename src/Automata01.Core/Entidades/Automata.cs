using System;
using System.Collections.Generic;
using Automata01.Core.Enums;

namespace Automata01.Core.Entidades
{
    public sealed class Automata
    {
        public Automata(IList<char> alphabet, IList<string> grammar, IDictionary<int, Node> nodes)
        {
            Alphabet = alphabet;
            Grammar = grammar;
            Nodes = nodes;
        }

        public IList<char> Alphabet { get; }
        public IList<string> Grammar { get; }
        public IDictionary<int, Node> Nodes { get; }
        public int FinalState => Nodes.Count - 1;

        public bool IsValidSequence(IList<char> input, Action<string> printValue)
        {
            var numberOfNodes = Nodes.Count;
            var currentNode = 0;

            for (var i = 0; i < input.Count; i++)
            {
                var currentChar = input[i];

                if (!BelongsToAlphabet(currentChar))
                {
                    printValue($" ERROR: The character ${currentChar} does not belong to the alphabet");
                    return false;
                }
                
                var direction = Nodes[currentNode].Transition(currentChar);
                currentNode = NextNode(direction, currentNode);
            }

            return currentNode == FinalState;
        }

        private bool BelongsToAlphabet(char value)
            => Alphabet.Contains(value);

        private int NextNode(Direction direction, int currentNode)
        {
            switch (direction)
            {
                case Direction.Left:
                    return --currentNode;
                case Direction.Right:
                    return ++currentNode;
                default:
                    return currentNode;
            }
        }
    }
}
