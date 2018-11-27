using FootballGround.Common.MenuHelper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballGround.Web.BaseControllers
{
    public abstract class BaseMenuController : Controller
    {
        public List<MenuItem> BuildMenu { get; set; }
        private void InitMenu()
        {
            BuildMenu = new List<MenuItem>();

            List<MenuItem> ListItems = new List<MenuItem>
             {

                new MenuItem
                {
                    Title ="Quản lý người dùng",
                    Icon ="glyphicon glyphicon-home",
                    Link ="UserManger/Index",
                }
            };
            BuildMenu.AddRange(ListItems);
        }
        public BaseMenuController()
        {
            InitMenu();
        }
        public ActionResult _LeftMenu()
        {
            //userName        
            return PartialView(BuildMenu);
        }

    }

  


}