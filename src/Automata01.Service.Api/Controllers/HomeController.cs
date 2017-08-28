using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Automata01.Core.Entidades;
using Automata01.Core.Enums;
using Automata01.Core.Shared;
using Automata01.Service.Api.ViewModels;

namespace Automata01.Service.Api.Controllers
{
    public sealed class HomeController : ApiController
    {
        private Automata _automata;
        private readonly AutomataService _automataService;

        public HomeController()
        {
            _automataService = new AutomataService();
        }

        [HttpGet]
        public IHttpActionResult Get(InputVM vm)
        {
            var result = new List<string>();
            _automata = new Automata(vm.Alphabet.Split(',').SelectMany(x => x.ToCharArray()).ToList(), vm.Grammar.Split('|').SelectMany(x => x.ToCharArray()).ToList(),
                _automataService.MapperToNodes(vm.Coordinates));
            _automata.IsValidSequence(s => result.Add(s));
            return Ok(result);
        }
    }

    public class AutomataService
    {
        public IReadOnlyCollection<Node> MapperToNodes(string input)
        {
            //format: new Node(0, new Dictionary<char, Direction>{{ 'a', Direction.None }, { 'b', Direction.Right} }),
            // "0 a,none; b,direita#"

            var values = input.Replace("\n", "").Split('#');
            var result = new List<Node>();
            
            foreach (var v in values.Where(x => x != ""))
            {
                var state = Convert.ToInt16(v[0].ToString());
                var lines = v.Substring(2).Split(';');
                var dict = new Dictionary<char, Direction>();

                foreach (var line in lines)
                {
                    var nodeChar = line.Trim()[0];
                    var nodeDirection = line.Replace(',',' ').Trim().Substring(1).ToDirection();

                    dict.Add(nodeChar, nodeDirection);
                }

                result.Add(new Node(state, dict));
            }

            return result;
        }
    }
}