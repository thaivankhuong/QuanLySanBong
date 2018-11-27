using FootballGround.Business.Repositories.IRepositories;
using FootballGround.Core.Model;
using FootballGround.Core.StoredModel;
using FootballGround.Data.Repositories;
using FootballGround.Data.Repositories.IRepositories;
using FootballGround.Web.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FootballGround.Core.DatatableJS.Datatables;
namespace FootballGround.Web.Controllers
{
    [FilterPermission(PermissionName = "FootballGround.UserManger")]
    public class UserMangerController : Controller
    {
        // GET: UserManger
        public PermissionRepostiory permissionRepostiory;
        public UserMangerController()
        {
            permissionRepostiory = new PermissionRepostiory();
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetData(DataTableAjaxPostModel parram, Employesss Employeee)
        {
            JsonResult result = new JsonResult();
            try
            {
                // Loading.
                List<ApplicationUserLoginViewModel> data = permissionRepostiory.Get_listUser(parram.start, parram.length, parram.search.value);
                // Total record count.
                int totalRecords = Convert.ToInt32(data.Count > 0 ? data[0].Total : 0 );
                // Filter record count.
                int recFilter = Convert.ToInt32(data.Count > 0 ? data[0].Total : 0);
                result = this.Json(new { draw = Convert.ToInt32(parram.draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }
            return result;
        }
    }
    public class Employesss
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}