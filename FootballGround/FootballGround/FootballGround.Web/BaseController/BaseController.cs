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
        public PermissionRepostiory permissionRepostiory;
        protected BaseController()
        {
            permissionRepostiory = new PermissionRepostiory();
        }

        protected bool HasPermission(string permissionName)
        {
            return permissionRepostiory.TryCheckAccess(permissionName, User.Identity);
        }
    }
}