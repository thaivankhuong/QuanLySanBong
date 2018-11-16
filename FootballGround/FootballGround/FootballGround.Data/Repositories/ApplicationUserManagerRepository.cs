using FootballGround.Data.Repositories.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballGround.Core.Model;
using FootballGround.Core.Infrastructure.ImplementInterfaces;
using FootballGround.Core.Infrastructure.Interfaces;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using FootballGround.Core.Infrastructure;
using Microsoft.AspNet.Identity;
using System.Timers;

namespace FootballGround.Data.Repositories.ImplementInterfacesRepositories
{
    public class ApplicationUserManagerRepository : Disposable, IApplicationUserManagerRepository
    {
        private ApplicationUserManager dataContext;
        private ApplicationUserManager DbContext
        {
            get { return dataContext ?? (dataContext = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()); }
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
       
            return DbContext.CreateAsync(user, password);
       
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return DbContext.Users;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(string UserId)
        {
            return DbContext.GenerateEmailConfirmationTokenAsync(UserId);
        }

        public Task<IdentityResult> ResetPasswordAsync(string UserId, string token, string Newpassword)
        {
            return DbContext.ResetPasswordAsync(UserId,token,Newpassword);
        }

        public Task SendEmailAsync(string UserId, string Subject, string Body)
        {
            return DbContext.SendEmailAsync(UserId, Subject, Body);
           
        }


        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
                dataContext = null;
            }
        }

        Task<ApplicationUser> FindByNameAsync(string UserName)
        {
            return DbContext.FindByNameAsync(UserName);
        }

      

       
    }
}
