using System;
using System.Collections.Generic;
using Automata01.Core.Entidades;
using Automata01.Core.Enums;
using static System.Console;

namespace Automata01.Presentation.Cmd
{
    public class Program
    {
        static void Main(string[] args)
        {
            var automata = new Automata(new List<char> { 'a', 'b', 'c' }, new List<string>(), 4, new Dictionary<int, IDictionary<char, Direction>>
            {
                {0, new Dictionary<char, Direction>{{ 'a', Direction.None }, { 'b', Direction.Right} } },
                {1, new Dictionary<char, Direction>{{ 'a', Direction.Left }, { 'b', Direction.None}, { 'c', Direction.Right } } },
                {2, new Dictionary<char, Direction>{{ 'a', Direction.None }, { 'b', Direction.Right} } },
                {3, new Dictionary<char, Direction>{{ ' ', Direction.None }}}
            });

            var isValid = automata.IsValidSequence(new List<char> { 'a', 'a', 'a', 'b', 'c', 'b' }, WriteLine);

            if (isValid)
                WriteLine("ESTADO FINAL!!!!");

            ReadKey();
        }
    }
}
