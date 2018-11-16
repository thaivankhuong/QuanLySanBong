using FootballGround.Data.Repositories.InterfaceRepositories;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FootballGround.Data.Repositories.ImplementInterfacesRepositories
{
    public class ApplicationSignOutManagerRepository : IApplicationSignOutManagerRepository
    {
        public ApplicationSignOutManagerRepository()
        {

        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public void SignOut(params string[] authenticationTypes)
        {
            AuthenticationManager.SignOut(authenticationTypes);
        }
    }
}
