using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballGround.Common.IdentityMethods;
using FootballGround.Business.Repositories.IRepositories;
using FootballGround.Data.Repositories;
using System.Web.Routing;
using FootballGround.Core.Depedency;
using FootballGround.Data.Repositories.IRepositories;

namespace FootballGround.Web.ActionFilters
{
    public class FilterPermission : AuthorizeAttribute
    {
        public string PermissionName { get; set; }
        private readonly IResolveDependencies dependenciesResolver;
        private IPermissionRepostiory permissionRepostiory;

        public FilterPermission()
        {
            dependenciesResolver = System.Web.Mvc.DependencyResolver.Current.GetService<IResolveDependencies>();
            permissionRepostiory = dependenciesResolver.Resolve<IPermissionRepostiory>();
        }
     
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(!permissionRepostiory.TryCheckAccess(PermissionName, filterContext.HttpContext.User.Identity))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" },
                        { "controller", "Unauthorised" } });
            }
           
        }
    }
}