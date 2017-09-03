using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Automata01.Core.Entidades;
using Automata01.Service.Api.Mappers;
using Automata01.Service.Api.ViewModels;

namespace Automata01.Service.Api.Controllers
{
    [RoutePrefix("api")]
    public sealed class HomeController : ApiController
    {
        private Automata _automata;
        private readonly NodeMapper _nodeMapper;

        public HomeController()
        {
            _nodeMapper = new NodeMapper();
        }

        [HttpPost]
        public IHttpActionResult Get(InputVM vm)
        {
            var result = new List<string>();
            _automata = new Automata(vm.Alphabet.Split(',').SelectMany(x => x.ToCharArray()).ToList(), vm.Grammar.Split('|').SelectMany(x => x.ToCharArray()).ToList(),
                _nodeMapper.Trasform(vm.Coordinates));
            _automata.IsValidSequence2(s => result.Add(s));
            return Ok(result);
        }
    }
}