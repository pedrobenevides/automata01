using System;
using System.Collections.Generic;
using System.Linq;
using Automata01.Core.Entidades;
using Automata01.Core.Shared;
using Automata01.Service.Api.Interfaces;

namespace Automata01.Service.Api.Mappers
{
    public class NodeMapper : IMapper<Node>
    {
        public IReadOnlyCollection<Node> Trasform(string input)
        {
            var values = input.Replace("\n", "").Split('#');
            var result = new List<Node>();

            foreach (var v in values.Where(x => x != ""))
            {
                var state = Convert.ToInt16(v[0].ToString());
                var lines = v.Substring(2).Split(';');
                var dict = new Dictionary<char, int>();
                var isFinalState = false;

                foreach (var line in lines)
                {
                    var nodeChar = line.Trim()[0];

                    var nodeDirection = line.ToNextMove();

                    if (nodeChar == 'n')
                        for (var i = 0; i < 10; i++)
                            dict.Add(i.ToString()[0], nodeDirection);
                    else
                        dict.Add(nodeChar, nodeDirection);


                    isFinalState = line.EndsWith("*");
                }

                result.Add(new Node(state, dict, isFinalState));
            }

            return result;
        }
    }
}