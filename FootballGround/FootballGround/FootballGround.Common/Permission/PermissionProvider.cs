using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Common.Permission
{
   public class PermissionProvider
    {
        public PermissionProvider()
        {
            ImpliedBy = new List<PermissionProvider>();
        }
        public string PermissionName { get; set; }
        public string DisplayName { get; set; }
        public bool IsHidden { get; set; }
        public ICollection<PermissionProvider> ImpliedBy { get; set; }
    }
}
