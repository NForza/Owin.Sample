using System.Web.Http;

namespace DemoApp.Controllers
{
    public class TestController: ApiController
    {
        [Route("test")]
        public string Get()
        {
            return "api";
        }
    }
}
