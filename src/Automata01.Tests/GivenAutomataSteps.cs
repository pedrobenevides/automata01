using System.Collections.Generic;
using Automata01.Service.Api.Controllers;
using Automata01.Service.Api.ViewModels;
using TechTalk.SpecFlow;
using System.Web.Http;
using System.Web.Http.Results;
using NUnit.Framework;

namespace Automata01.Tests
{
    [Binding]
    public class GivenAutomataSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HomeController _sut;
        private string _input;

        public GivenAutomataSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sut = new HomeController();
        }

        [Given(@"some input for automata")]
        public void GivenSomeInputForAutomata()
        {
            _input = "0 a,none; b,->#\n" +
                "1 a,<-; b,none;c->#\n" +
                "2 a,none;b,->#\n" +
                "3  , nonde#\n";
        }
        
        [Given(@"i send it via web")]
        public void GivenISendItViaWeb()
        {
            var vm = new InputVM
            {
                Coordinates = _input,
                Alphabet = "a,b,c",
                Grammar = "a|a|a|b|c|b"
            };

            _scenarioContext.Set(_sut.Get(vm));
        }
        
        [When(@"the automata readit")]
        public void WhenTheAutomataReadit()
        {
        }
        
        [Then(@"return ok with the steps")]
        public void ThenReturnOkWithTheSteps()
        {
            var result = ((OkNegotiatedContentResult<List<string>>)_scenarioContext.Get<IHttpActionResult>()).Content;
            Assert.AreEqual(6, result.Count);
        }
    }
}
