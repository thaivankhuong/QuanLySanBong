using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FootballGround.Common.MenuHelper
{
    public static class ActiveMenu
    {
        public static string IsActive( string control, string action)
        {
            var routeValues =  HttpContext.Current.Request.RequestContext.RouteData.Values;
            var pathQuery = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
            if (pathQuery.Equals("/"))
            {
                return "";
            }
            string actionName = string.Empty;
            string controllerName = string.Empty;
            if (routeValues != null)
            {
                if (routeValues.ContainsKey("action"))
                {
                    actionName = routeValues["action"].ToString();
                }
                if (routeValues.ContainsKey("controller"))
                {
                    controllerName = routeValues["controller"].ToString();
                }
            }
            var returnActive = control == controllerName &&
                               action == actionName;

            return returnActive ? "active" : "";
        }

    }
}
