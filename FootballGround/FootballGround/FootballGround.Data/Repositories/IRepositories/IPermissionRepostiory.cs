using FootballGround.Core.Infrastructure.Interfaces;
using FootballGround.Core.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Data.Repositories.IRepositories
{
   public interface IPermissionRepostiory : IRepository<PermissionInUserRoles>
    {
        bool TryCheckAccess(string permissionName, IIdentity user);
    }
}
