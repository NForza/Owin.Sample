using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApplication1;
using DemoApp;

namespace DemoAppTest
{
    class DemoApp: TestApp<Startup>
    {
    }

    internal static class HttpResponseMessageExtensions
    {
        public static Task<string> GetContentAsStringAsync(this HttpResponseMessage message)
        {
            return message.Content.ReadAsStringAsync();
        }
    }
}
