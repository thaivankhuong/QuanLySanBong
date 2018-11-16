using FootballGround.Core.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Data.Repositories.InterfaceRepositories
{
    public interface IApplicationSignInManagerRepository
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isRememberMe, bool isLock);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);
    }
}
