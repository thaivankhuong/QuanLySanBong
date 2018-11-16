using FootballGround.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Business.Repositories.IRepositories
{
    public interface IApplicationUserBusiness
    {
        IEnumerable<ApplicationUser> GetAll();
    }

}
