using FootballGround.Core.Infrastructure.Interfaces;
using FootballGround.Core.Model;
using FootballGround.Core.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Data.Repositories.IRepositories
{
   public interface IPermissionRepostiory : IRepository<ApplicationUser>
    {
        bool TryCheckAccess(string permissionName, IIdentity user);
        List<ApplicationUserLoginViewModel> Get_listUser(int intstartRec, int PageSize, string keyword);
    }
}
