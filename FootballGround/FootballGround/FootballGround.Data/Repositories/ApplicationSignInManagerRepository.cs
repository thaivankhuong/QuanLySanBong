using FootballGround.Core.Infrastructure;
using FootballGround.Core.Model;
using FootballGround.Data.Repositories.InterfaceRepositories;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;


namespace FootballGround.Data.Repositories.ImplementInterfacesRepositories
{
   public class ApplicationSignInManagerRepository : Disposable, IApplicationSignInManagerRepository
    {
        private ApplicationSignInManager dataContext;
        private ApplicationSignInManager DbContext
        {
            get { return dataContext ?? (dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>()); }
        }

        public Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isRememberMe, bool isLock)
        {
            return DbContext.PasswordSignInAsync(userName, password, isRememberMe, isLock);
        }

        public Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
         
            return DbContext.SignInAsync(user, isPersistent, rememberBrowser);
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
                dataContext = null;
            }
        }

        
    }
}
