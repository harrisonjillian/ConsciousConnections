using Autofac;
using Autofac.Integration.Mvc;
using ConsciousConnections.Contracts;
using ConsciousConnections.Data;
using ConsciousConnections.Services;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(ConsciousConnections.Startup))]
namespace ConsciousConnections
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //// OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();
            //builder.RegisterType<CompanyService>().As<ICompanyService>();
            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<ReviewService>().As<IReService>();
            //// Set the dependency resolver to be Autofac.
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            ConfigureAuth(app);
        }
    }
}
