using System;
using System.Collections.Generic;
using System.Linq;
using Automata01.Core.Enums;

namespace Automata01.Core.Entidades
{
    public sealed class Automata
    {
        public Automata(IReadOnlyCollection<char> alphabet, IReadOnlyCollection<char> grammar, int nodes, IReadOnlyCollection<Node> universe)
        {
            Alphabet = alphabet;
            Grammar = grammar;
            Nodes = nodes;

            if (!IsValidUniverse(universe.ToList()))
                throw new Exception("This is not a valid universe");

            Universe = universe;
        }

        public IReadOnlyCollection<char> Alphabet { get; }
        public IReadOnlyCollection<char> Grammar { get; }
        public int Nodes { get; }
        public int FinalState => Nodes - 1;
        public IReadOnlyCollection<Node> Universe { get; }

        public bool IsValidSequence(Action<string> printValue)
        {
            var currentNode = 0;

            foreach (var currentChar in Grammar)
            {
                if (!BelongsToAlphabet(currentChar))
                {
                    printValue($" ERROR: The character ${currentChar} does not belong to the alphabet");
                    return false;
                }

                var direction = GetDirection(currentNode, currentChar);

                printValue($"Estou no estado Q{currentNode} ao ler [{currentChar}] {LogNext(direction, currentNode)}");
                currentNode = NextNode(direction, currentNode);
            }

            return currentNode == FinalState;
        }

        private Direction GetDirection(int currentNode, char currentChar) 
            => Universe.First(u => u.State == currentNode).Possibities.First(p => p.Key == currentChar).Value;

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

        private static string LogNext(Direction direction, int currentNode)
        {
            switch (direction)
            {
                case Direction.Left:
                    return $"volta para Q{currentNode - 1}";
                case Direction.Right:
                    return $"vai para Q{currentNode + 1}";
                default:
                    return $"continua em Q{currentNode}";
            }
        }

        private static bool IsValidUniverse(ICollection<Node> universe)
        {
            var count = universe.Count;
            var states = universe.Select(u => u.State).Distinct().Count();

            return count == states;
        }
    }
}
