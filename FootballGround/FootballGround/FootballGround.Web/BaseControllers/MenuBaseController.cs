using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballGround.Data.Repositories.IRepositories;
using FootballGround.Common.MenuHelper;
using System.Web.Mvc;

namespace FootballGround.Web.BaseControllers
{
    public abstract class MenuBaseController : BaseController
    {
        public MenuBaseController()
        {

        }
        protected abstract List<MenuItem> ListMenus();

    }
}