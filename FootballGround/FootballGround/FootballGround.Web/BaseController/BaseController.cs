using FootballGround.Core.Depedency;
using FootballGround.Data.Repositories;
using FootballGround.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballGround.Web.BaseController
{
    public abstract class BaseController : Controller
    {
        public IResolveDependencies dependenciesResolver;
        private IPermissionRepostiory permissionRepostiory;
        public BaseController()
        {
            dependenciesResolver = System.Web.Mvc.DependencyResolver.Current.GetService<IResolveDependencies>();
            permissionRepostiory = dependenciesResolver.Resolve<IPermissionRepostiory>();
        }

        protected bool HasPermission(string permissionName)
        {
            return permissionRepostiory.TryCheckAccess(permissionName, User.Identity);
        }
    }
}