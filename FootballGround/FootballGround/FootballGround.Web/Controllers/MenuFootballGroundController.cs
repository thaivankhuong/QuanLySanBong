using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballGround.Common.MenuHelper;
using FootballGround.Data.Repositories.IRepositories;
using FootballGround.Web.BaseController;

namespace FootballGround.Web.Controllers
{
    public class MenuFootballGroundController : MenuBaseController
    {
       public MenuFootballGroundController()
        {

        }
        public ActionResult LeftMenu()
        {
            return PartialView(ListMenus());
        }

        protected override List<MenuItem> ListMenus()
        {
            List<MenuItem> BuildMenu = new List<MenuItem>();

           if(HasPermission("FootballGround.UserManger"))
            {               
                BuildMenu.Add(
                    
                    new MenuItem
                    {
                        Title = "Quản lý người dùng",
                        Icon = "glyphicon glyphicon-home",
                        Link = "UserManger/Index",
                    }
                );
            }

            return BuildMenu;
        }
    }
}