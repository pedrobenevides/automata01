using System;
using System.Collections.Generic;
using System.Linq;

namespace Automata01.Core.Entidades
{
    public sealed class FiniteDeterministic : Automata
    {
        public FiniteDeterministic(IReadOnlyCollection<char> alphabet, IReadOnlyCollection<char> grammar, IReadOnlyCollection<Node> universe) 
            : base(alphabet, grammar, universe)
        { }
        
        public override bool IsValidSequence(Action<string> printValue)
        {
            var currentNode = Universe.OrderBy(u => u.State).First();

            foreach (var currentChar in Grammar)
            {
                if (!BelongsToAlphabet(currentChar))
                {
                    printValue($" ERROR: The character ${currentChar} does not belong to the alphabet");
                    break;
                }

                var nextNode = GetNextNode(currentNode, currentChar);
                printValue($"Estou no estado Q{currentNode.State} ao ler [{currentChar}] {LogNext(nextNode.State, currentNode.State)}");

                currentNode = nextNode;
            }

            var isValid = currentNode.IsFinalState;

            printValue(isValid
                ? $"Q{currentNode.State} é o estado final !!"
                : $"Autômato inválido Q{currentNode.State} não é estado final");

            return isValid;
        }

        private Node GetNextNode(Node currentNode, char currentChar)
        {
            var nextNodeNumber = Universe.First(u => u.State == currentNode.State).Possibities.First(p => p.Key == currentChar).Value;
            return Universe.First(u => u.State == nextNodeNumber);
        }
    }
}
