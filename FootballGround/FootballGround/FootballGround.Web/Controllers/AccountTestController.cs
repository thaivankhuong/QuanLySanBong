using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballGround.Web.Controllers
{
    
    public class AccountTestController : FootballGround.Web.BaseController.BaseController 
    {
        // GET: AccountTest
        public ActionResult Index()
        {
            return View();
        }
    }
}