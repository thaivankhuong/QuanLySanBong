using FootballGround.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using FootballGround.Core.SqlModel;
using FootballGround.Core.Infrastructure;
using FootballGround.Core.Infrastructure.Interfaces;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web.Security;
using FootballGround.Core.Model;

namespace FootballGround.Data.Repositories
{
    public class PermissionRepostiory : RepositoryBase<ApplicationUser>, IPermissionRepostiory
    {
        public PermissionRepostiory()
        {

        }

        public bool TryCheckAccess(string permissionName, IIdentity user)
        {
            var claimsIdentity = user as ClaimsIdentity;
            var roles = claimsIdentity.Claims
                                        .Where(c => c.Type == ClaimTypes.Role)
                                        .Select(c => c.Value).ToList();

            if (claimsIdentity != null && claimsIdentity.IsAuthenticated)
            {
                if (roles.Contains("Administrator"))
                {
                    return true;
                }
                else if (claimsIdentity != null)
                {
                    var stringId = claimsIdentity.Claims
                                                 .FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier);

                    var Id = new SqlParameter("Id", stringId.Value);
                    var PermissionName = new SqlParameter("PermissionName", permissionName);
                    var storeName = "GetPermissionById";

                    return this.DbContext.ExecuteStoredProcedure<PermissionInUserRoles>
                            (storeName, Id, PermissionName).Any();
                }
            }
            return false;
        }
    }
}
