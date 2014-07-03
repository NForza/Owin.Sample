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
#if DEBUG
            app.UseErrorPage();
#endif
            app.Map("/test", builder => builder.Run(environment =>
            {
                environment.Response.ContentType = "text/plain";
                return environment.Response.WriteAsync("Hello World");
            }));
           
            app.Map("/site", builder => builder.UseNancy());
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.Map("/api", builder => builder.UseWebApi(config));
             
            app.UseCors(CorsOptions.AllowAll);

            StaticFileOptions options = new StaticFileOptions()
            {
                RequestPath = new PathString("/Scripts"),
                FileSystem = new PhysicalFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts"))
            };
            app.UseStaticFiles(options);            

            app.MapSignalR();
        }
    }
}