using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Common.Permission
{
   public interface IPermissionApplication
    {
        IEnumerable<PermissionProvider> GetPermissions();
    }
}
