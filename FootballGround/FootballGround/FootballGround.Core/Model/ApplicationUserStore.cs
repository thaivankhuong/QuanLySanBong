using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Core.Model
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, 
        IUserStore<ApplicationUser>, 
        IDisposable
    {
        public ApplicationUserStore(FootballGroundDbContext context) : base(context) { }
    }
}
