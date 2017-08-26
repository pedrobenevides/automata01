using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Automata01.Core.Entidades;
using Automata01.Core.Enums;
using static System.Console;

namespace Automata01.Presentation.Cmd
{
    public class Program
    {
        static void Main(string[] args)
        {
            var q0 = new Node("q0", s =>
            {
                var textDefault = "Estou em um estado Q0 e";

                if (s == 'a')
                {
                    WriteLine($"{textDefault} li [a] continuo em Q0");
                    return Direction.None;
                }

                if (s == 'b')
                {
                    WriteLine($"{textDefault} li [b] vou para o estado seguinte");
                    return Direction.Right;
                }

                throw new Exception("Letra não reconhecida pelo alfabeto ou por esse estado.");
            });

            var q1 = new Node("q1", s =>
            {
                var textDefault = "Estou em um estado Q1 e";

                if (s == 'a')
                {
                    WriteLine($"{textDefault} li [a] volto para o estado anterior");
                    return Direction.Left;
                }

                if (s == 'b')
                {
                    WriteLine($"{textDefault} li [b] continuo em Q1");
                    return Direction.None;
                }

                if (s == 'c')
                {
                    WriteLine($"{textDefault} li [c] vou para o estado seguinte");
                    return Direction.Right;
                }

                throw new Exception("Letra não reconhecida pelo alfabeto.");
            });

            var q2 = new Node("q2", s =>
            {
                var textDefault = "Estou em um estado Q2 e";

                if (s == 'a')
                {
                    WriteLine($"{textDefault} li [a] volto para o estado anterior");
                    return Direction.None;
                }

                if (s == 'b')
                {
                    WriteLine($"{textDefault} li [a] vou para o estado seguinte");
                    return Direction.Right;
                }

                throw new Exception("Letra não reconhecida pelo alfabeto.");
            });

            var q3 = new Node("q3", s => Direction.None);

            var automata = new Automata(new List<char> { 'a', 'b', 'c' }, new List<string>(), new Dictionary<int, Node> { { 0, q0 }, { 1, q1 }, { 2, q2 }, { 3, q3 } });
            var isValid = automata.IsValidSequence(new List<char> { 'a', 'b', 'c', 'b', 'a' }, WriteLine);

            if (isValid)
                WriteLine("ESTADO FINAL!!!!");

            ReadKey();
        }
    }
}
