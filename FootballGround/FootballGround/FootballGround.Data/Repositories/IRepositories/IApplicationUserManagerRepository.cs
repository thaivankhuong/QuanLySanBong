using FootballGround.Core.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FootballGround.Data.Repositories.InterfaceRepositories
{
    public interface IApplicationUserManagerRepository 
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(string UserId);

        Task SendEmailAsync(string UserId, string Subject, string Body);

    

        Task<IdentityResult> ResetPasswordAsync(string UserId, string token, string Newpassword);
  


    }
}
