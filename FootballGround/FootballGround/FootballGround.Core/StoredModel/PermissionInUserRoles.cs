using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Core.SqlModel
{
    public class PermissionInUserRoles
    {
        public string UserName { get; set; }
        public bool IsSysAdmin { get; set; }
        public string DisplayName { get; set; }
    }
}
