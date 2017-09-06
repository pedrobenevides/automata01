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
        //0 a, 0; b, 2; c, 3;
        [Given(@"some input for automata")]
        public void GivenSomeInputForAutomata() => _input = "0 +,1; -,1; n,1#\n" +
                                                            "1 n,2#\n" +
                                                            "2 n,2;.,3#\n" +
                                                            "3 n,4#\n" +
                                                            "4 n,4; e,5#\n" +
                                                            "5 +,6; -,6#\n" +
                                                            "6 n,7#\n" +
                                                            "7 n,7 *#\n";

        [Given(@"i send it via web")]
        public void GivenISendItViaWeb()
        {
            var vm = new InputVM
            {
                Coordinates = _input,
                Alphabet = "+,-,.,0,1,2,3,4,5,6,7,8,9,e",
                Grammar = "+|2|.|4|1|e|-|3" //"-|4|.|3|e|+|1|9"
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
            Assert.AreEqual(9, result.Count);
        }
    }
}
