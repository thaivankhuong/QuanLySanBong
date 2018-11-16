using FootballGround.Business.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballGround.Core.Model;
using FootballGround.Data.Repositories.ImplementInterfacesRepositories;

namespace FootballGround.Business.Repositories
{
    public class ApplicationUserBusiness : IApplicationUserBusiness
    {
        private ApplicationUserManagerRepository applicationUserManagerRepository;
        public ApplicationUserBusiness()
        {
            applicationUserManagerRepository = new ApplicationUserManagerRepository();
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
           return applicationUserManagerRepository.GetAll();
        }
    }
}
