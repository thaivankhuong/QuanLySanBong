using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Core.Model
{
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public bool IsSysAdmin { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }    

    }
}
