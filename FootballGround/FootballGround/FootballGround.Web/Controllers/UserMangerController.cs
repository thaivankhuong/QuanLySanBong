using FootballGround.Business.Repositories.IRepositories;
using FootballGround.Data.Repositories.IRepositories;
using FootballGround.Web.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballGround.Web.Controllers
{
 [FilterPermission(PermissionName= "FootballGround.UserManger")]
    public class UserMangerController : Controller
    {
        // GET: UserManger

        public UserMangerController()
        {
           
        }
        public ActionResult Index()
        {
          
           return View();
        }
    }
}