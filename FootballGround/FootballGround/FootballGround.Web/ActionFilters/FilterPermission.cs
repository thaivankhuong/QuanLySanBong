using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballGround.Common.IdentityMethods;
using FootballGround.Business.Repositories.IRepositories;
using FootballGround.Data.Repositories;
using System.Web.Routing;

namespace FootballGround.Web.ActionFilters
{
    public class FilterPermission : AuthorizeAttribute
    {
        public string PermissionName { get; set; }
        private PermissionRepostiory permissionRepostiory;
        public FilterPermission()
        {
            permissionRepostiory = new PermissionRepostiory();
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