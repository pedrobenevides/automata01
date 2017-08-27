using Automata01.Service.Api.App_Start;
using Owin;

namespace Automata01.Service.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Configure(app);
        }
    }
}