using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Data.Repositories.InterfaceRepositories
{
    public interface IApplicationSignOutManagerRepository
    {
        void SignOut(params string[] authenticationTypes);
    }
}
