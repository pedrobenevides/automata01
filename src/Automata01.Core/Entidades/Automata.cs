using System;
using System.Collections.Generic;

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

        public bool IsValidSequence(IList<string> input)
        {
            for (var i = 0; i < input.Count; i++)
            {
                //TODO
            }

            return true;
        }
    }

    public class Node
    {
        private readonly Func<string, Direction> _action;

        public Node(string stateValue, Func<string, Direction> action)
        {
            _action = action;
            StateValue = stateValue;
        }

        public Direction Direction { get; set; }
        public string StateValue { get; private set; }

        public Direction Transition(string value) => _action(value);
    }

    public enum Direction
    {
        Left,
        Right,
        None
    }

    public class Main
    {
        public void Teste()
        {
            var q0 = new Node("q0", s =>
            {
                if (s == "a")
                    return Direction.None;

                if (s == "b")
                    return Direction.Right;

                throw new Exception("Letra não reconhecida pelo alfabeto ou por esse estado.");
            });

            var q1 = new Node("q1", s =>
            {
                if (s == "a")
                    return Direction.Left;

                if (s == "b")
                    return Direction.None;

                if (s == "c")
                    return Direction.Right;

                throw new Exception("Letra não reconhecida pelo alfabeto.");
            });

            var automata = new Automata(new List<char> { 'a', 'b', 'c' }, new List<string>(), new Dictionary<int, Node> { { 0, q0 }, { 1, q1 } });

        }
    }
}
