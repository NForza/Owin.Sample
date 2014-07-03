using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Nancy.Owin;
using Owin;

namespace DemoApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UseErrorPage(app);
            UseCustomLoggingMiddleware(app);
            HandleRequest(app);
            UseStaticFiles(app);

            app = UseLoggingFromHereOn(app);
            
            UseWebApi(app);
            UseNancy(app);
            UseSignalR(app);
        }

        private IAppBuilder UseLoggingFromHereOn(IAppBuilder app)
        {
            return app.Use(LoggingMiddleware);
        }

        private void UseCustomLoggingMiddleware(IAppBuilder app)
        {
            app.Map("/log", builder => builder.Use(LoggingMiddleware).Run( environment =>
            {
                environment.Response.ContentType = "text/plain";
                return environment.Response.WriteAsync("Hello World");
            }));
        }

        private async Task LoggingMiddleware(IOwinContext context, Func<Task> next)
        {
            Console.WriteLine("Before call - {0}", context.Request.QueryString);
            await next();
            Console.WriteLine("After call - {0}", context.Request.QueryString);
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
            NancyOptions options = new NancyOptions {Bootstrapper = new OwinDemoBootstrapper()};

            app.Map("/site", builder => builder.UseNancy(options));
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