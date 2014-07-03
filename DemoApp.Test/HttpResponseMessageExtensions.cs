using System.Net.Http;
using System.Threading.Tasks;

namespace DemoAppTest
{
    internal static class HttpResponseMessageExtensions
    {
        public static Task<string> GetContentAsStringAsync(this HttpResponseMessage message)
        {
            return message.Content.ReadAsStringAsync();
        }
    }
}