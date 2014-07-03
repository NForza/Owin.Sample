using System;
using System.IO;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace DemoApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UseErrorPage(app);
            HandleRequest(app);
            UseNancy(app);
            UseWebApi(app);
            UseStaticFiles(app);
            UseSignalR(app);
        }

        private static void UseErrorPage(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
#endif
        }

        private static void UseSignalR(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }

        private static void UseStaticFiles(IAppBuilder app)
        {
            StaticFileOptions options = new StaticFileOptions()
            {
                RequestPath = new PathString("/Scripts"),
                FileSystem = new PhysicalFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts"))
            };
            app.UseStaticFiles(options);
        }

        private static void UseWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.Map("/api", builder => builder.UseWebApi(config));
        }

        private static void UseNancy(IAppBuilder app)
        {
            app.Map("/site", builder => builder.UseNancy());
        }

        private static void HandleRequest(IAppBuilder app)
        {
            app.Map("/test", builder => builder.Run(environment =>
            {
                environment.Response.ContentType = "text/plain";
                return environment.Response.WriteAsync("Hello World");
            }));
        }
    }
}