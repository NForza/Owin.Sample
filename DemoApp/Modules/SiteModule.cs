using DemoApp.ViewModels;
using Nancy;

namespace ConsoleApplication1.Modules
{
    public class SiteModule: NancyModule
    {
        public SiteModule()
        {
            Get["/"] = o => View["Home", new HomeViewModel { WelcomeMessage = "Hello World"}];
        }
    }
}
