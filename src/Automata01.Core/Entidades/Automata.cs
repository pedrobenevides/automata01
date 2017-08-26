using System;
using System.Collections.Generic;
using Automata01.Core.Enums;

namespace Automata01.Core.Entidades
{
    public sealed class Automata
    {
        public Automata(IList<char> alphabet, IList<string> grammar, int nodes, IDictionary<int, IDictionary<char, Direction>> universe)
        {
            Alphabet = alphabet;
            Grammar = grammar;
            Nodes = nodes;

            Universe = universe;
        }

        public IList<char> Alphabet { get; }
        public IList<string> Grammar { get; }
        public int Nodes { get; }
        public int FinalState => Nodes - 1;
        public IDictionary<int, IDictionary<char, Direction>> Universe { get; }

        public bool IsValidSequence(IList<char> input, Action<string> printValue)
        {
            var currentNode = 0;

            foreach (var currentChar in input)
            {
                if (!BelongsToAlphabet(currentChar))
                {
                    printValue($" ERROR: The character ${currentChar} does not belong to the alphabet");
                    return false;
                }

                var direction = Universe[currentNode][currentChar];

                printValue($"Estou no estado Q{currentNode} ao ler {currentChar} vou para a ${direction}");
                currentNode = NextNode(direction, currentNode);
            }

            return currentNode == FinalState;
        }

        private bool BelongsToAlphabet(char value)
            => Alphabet.Contains(value);

        private static int NextNode(Direction direction, int currentNode)
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
