using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using FootballGround.Core.Depedency;
using FootballGround.Data.Repositories.IRepositories;
using FootballGround.Data.Repositories;
using Autofac.Integration.Mvc;
using FootballGround.Data.Repositories.InterfaceRepositories;
using FootballGround.Data.Repositories.ImplementInterfacesRepositories;
using FootballGround.Common.Permission;

[assembly: OwinStartupAttribute(typeof(FootballGround.Web.Startup))]
namespace FootballGround.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           ConfigAutofac(app);
        }
 
        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new AutofacContainerAdapter();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            builder.Register<IPermissionRepostiory, PermissionRepostiory>();
            builder.Register<IApplicationUserManagerRepository, ApplicationUserManagerRepository>();
            builder.Register<IApplicationSignInManagerRepository, ApplicationSignInManagerRepository>();
            builder.Register<IApplicationSignOutManagerRepository,ApplicationSignOutManagerRepository>();
            builder.Register<IPermissionApplication, PermissionApplication>();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.RegisterInstance<IResolveDependencies>(builder);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.ContainerInstance));
        }
    }
}
