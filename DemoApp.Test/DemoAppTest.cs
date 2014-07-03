using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoAppTest
{
    [TestClass]
    public class DemoAppTest
    {
        [TestMethod]
        public async Task A_Get_Of_Test_Should_Result_In_HelloWorld()
        {
            (await new DemoApp().GetResponseContentAsync("/test")).Should().Be("Hello World");
        }

        [TestMethod]
        public async Task A_Get_Of_Api_Should_Result_In_Api()
        {
            (await new DemoApp().GetResponseContentAsync("/api/test")).Should().Be("\"api\"");
        }
        
        [TestMethod]
        public async Task A_Get_Of_Site_Should_Succeed()
        {
            var response = await new DemoApp().GetResponseAsync("/site");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.GetContentAsStringAsync();
            content.Should().Contain("<h1>Chat App</h1>");          
        }       
    }
}
