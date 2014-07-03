using System.Web.Http;

namespace ConsoleApplication1.Controllers
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
