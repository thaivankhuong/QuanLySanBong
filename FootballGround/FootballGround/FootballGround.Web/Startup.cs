﻿using Autofac;
using FootballGround.Core;
using FootballGround.Core.Infrastructure.ImplementInterfaces;
using FootballGround.Core.Infrastructure.Interfaces;
using FootballGround.Core.Model;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using System.Net.Http;
using FootballGround.Business.Repositories;
using FootballGround.Data.Repositories.ImplementInterfacesRepositories;

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
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
           // builder.Register
        



            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<FootballGroundDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
      
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();


           // Repositories
            builder.RegisterAssemblyTypes(typeof(ApplicationUserManagerRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Business
            builder.RegisterAssemblyTypes(typeof(ApplicationUserBusiness).Assembly)
               .Where(t => t.Name.EndsWith("Business"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            

        }
    }
}
