using System;
using System.Collections.Generic;
using System.Linq;

namespace Automata01.Core.Entidades
{
    public sealed class Automata
    {
        public Automata(IReadOnlyCollection<char> alphabet, IReadOnlyCollection<char> grammar, IReadOnlyCollection<Node> universe)
        {
            Alphabet = alphabet;
            Grammar = grammar;

            if (!IsValidUniverse(universe.ToList()))
                throw new Exception("This is not a valid universe");

            Universe = universe;
        }

        public IReadOnlyCollection<char> Alphabet { get; }
        public IReadOnlyCollection<char> Grammar { get; }
        public int FinalState => Universe.Select(u => u.State).Max();
        public IReadOnlyCollection<Node> Universe { get; }
        
        public bool IsValidSequence2(Action<string> printValue)
        {
            var currentNode = Universe.OrderBy(u => u.State).First();

            foreach (var currentChar in Grammar)
            {
                if (!BelongsToAlphabet(currentChar))
                {
                    printValue($" ERROR: The character ${currentChar} does not belong to the alphabet");
                    break;
                }

                var nextNode = GetDirection2(currentNode, currentChar);
                printValue($"Estou no estado Q{currentNode.State} ao ler [{currentChar}] {LogNext(nextNode.State, currentNode.State)}");

                currentNode = nextNode;
            }

            var isValid = currentNode.IsFinalState;

            printValue(isValid
                ? $"Q{currentNode.State} é o estado final !!"
                : $"Autômato inválido Q{currentNode.State} não é estado final");

            return isValid;
        }

        private Node GetDirection2(Node currentNode, char currentChar)
        {
            var nextNodeNumber = Universe.First(u => u.State == currentNode.State).Possibities.First(p => p.Key == currentChar).Value;
            return Universe.First(u => u.State == nextNodeNumber);
        }

        private bool BelongsToAlphabet(char value)
            => Alphabet.Contains(value);
        
        private static string LogNext(int nextNode, int currentNode) => nextNode > currentNode
            ? $"vai para Q{nextNode}"
            : nextNode < currentNode
                ? $"volta para Q{nextNode}"
                : $"permanece em Q{currentNode}";

        private static bool IsValidUniverse(ICollection<Node> universe)
        {
            var count = universe.Count;
            var states = universe.Select(u => u.State).Distinct().Count();

            return count == states;
        }
    }
}
