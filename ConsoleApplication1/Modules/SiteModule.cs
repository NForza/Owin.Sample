using Nancy;

namespace ConsoleApplication1.Modules
{
    public class SiteModule: NancyModule
    {
        public SiteModule()
        {
            Get["/"] = o => View["Home"];
        }
    }
}
