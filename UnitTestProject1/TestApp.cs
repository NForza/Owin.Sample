using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;

namespace DemoAppTest
{
    class TestApp<T>
    {
        public async Task<string> GetResponseContentAsync(string url)
        {
            using (var server = TestServer.Create<T>())
            {
                HttpResponseMessage response = await server.HttpClient.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<HttpStatusCode> GetResponseCodeAsync(string url)
        {
            using (var server = TestServer.Create<T>())
            {
                HttpResponseMessage response =
                    await server.HttpClient.GetAsync(url);

                return response.StatusCode;
            }
        }

        public async Task<HttpResponseMessage> GetResponseAsync(string url)
        {
            using (var server = TestServer.Create<T>())
            {
                return await server.HttpClient.GetAsync(url);
            }
        }

    }
}