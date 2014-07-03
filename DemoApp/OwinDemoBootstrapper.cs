using Autofac;
using Nancy;
using Nancy.Bootstrappers.Autofac;

namespace DemoApp
{
    class OwinDemoBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            var builder = new ContainerBuilder();           
            builder.Update(container.ComponentRegistry);
        }
    }
}

