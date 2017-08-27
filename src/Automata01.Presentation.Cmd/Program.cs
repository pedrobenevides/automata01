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
            var lista = new List<string>();
            var automata = new Automata(new List<char> { 'a', 'b', 'c' }.AsReadOnly(), new List<char> { 'a', 'a', 'a', 'b', 'c', 'b' }.AsReadOnly(), new List<Node>
            {
                new Node(0, new Dictionary<char, Direction>{{ 'a', Direction.None }, { 'b', Direction.Right} }),
                new Node(1, new Dictionary<char, Direction>{{ 'a', Direction.Left }, { 'b', Direction.None}, { 'c', Direction.Right } } ),
                new Node(2, new Dictionary<char, Direction>{{ 'a', Direction.None }, { 'b', Direction.Right} }),
                new Node(3, new Dictionary<char, Direction>{{ ' ', Direction.None }})
            }.AsReadOnly());

            var isValid = automata.IsValidSequence(WriteLine);

            if (isValid)
                WriteLine("ESTADO FINAL!!!!");

            ReadKey();
        }
    }
}
